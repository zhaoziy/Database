#include "stdafx.h"
#include "DatabaseCmd.h"
_COM_SMARTPTR_TYPEDEF(IADORecordBinding, __uuidof(IADORecordBinding));

DatabaseCmd::DatabaseCmd()
{
	m_pConn = NULL;
	m_pRecord = NULL;

	char szPath[MAX_BUFF]; 
	memset(szPath, 0, MAX_BUFF);

	if (strlen(szPath) > 0) {}

	SetConnStr();

	HRESULT hr = CoInitialize(NULL);

	if (FAILED(hr)) {}
}


DatabaseCmd::~DatabaseCmd()
{
	CoUninitialize();
}

bool DatabaseCmd::ConnDB(void) {
	bool bResult = false;
	if (NULL == m_pConn || adStateClosed == m_pConn->State) {
		if (strlen(m_szConnStr) > 0) {
			try
			{   //Connecting
				if (!FAILED(m_pConn.CreateInstance(_uuidof(Connection)))) { //设置连接超时时间
					m_pConn->CommandTimeout = 30;		//in seconds
					if (!FAILED(m_pConn->Open((_bstr_t)(m_szConnStr), "", "", adModeUnknown)))
						bResult = true;
				}
			}
			catch (_com_error e) {
				char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
				//sprintf(szLog, "连接数据库错误:%s\n", (char *)(e.Description()));
				//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
			}
			//	}
		}
	}

	return bResult;
}

bool DatabaseCmd::SelectSQL(const char *szSQL) {
	bool bResult = false;
	if (strlen(szSQL) > 0 && strlen(m_szConnStr) > 0) {
		if (NULL != m_pRecord/* || adStateClosed != m_pRecord->State*/)
			m_pRecord->Close();

		try
		{
			if (!FAILED(m_pRecord.CreateInstance(__uuidof(Recordset)))) {
				HRESULT hr = 0;
				if (NULL == m_pConn || adStateClosed == m_pConn->State)
					hr = m_pRecord->Open((_bstr_t)szSQL, _variant_t(m_szConnStr), adOpenKeyset, adLockOptimistic, adCmdText);
				else
					hr = m_pRecord->Open((_bstr_t)szSQL, m_pConn.GetInterfacePtr(), adOpenKeyset, adLockOptimistic, adCmdText);
				if (SUCCEEDED(hr))
					bResult = true;
			}
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			//sprintf(szLog, "执行SQL查询命令错误:%s[%s]", (char *)(e.Description()), szSQL);
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

//nRefreshNum受影响的记录数
bool DatabaseCmd::ExecuteSQL(const char *szSQLStr, long &nRefreshNum) {
	bool bResult = false;
	if (strlen(szSQLStr) > 0) {
		if (NULL == m_pConn || adStateClosed == m_pConn->State)
			ConnDB();
		try
		{
			_variant_t RefreshNum;
			m_pConn->Execute(_bstr_t(szSQLStr), &RefreshNum, adCmdText);
			bResult = true;
			nRefreshNum = RefreshNum.lVal;
		}
		catch (_com_error e)
		{
			nRefreshNum = 0;
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			//sprintf(szLog, "执行SQL命令错误:%s[%s]", (char *)(e.Description()), szSQLStr);
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

int DatabaseCmd::GetConnStr(char *szConnStr, int nBuffSize) {
	int nResult = 0;
	if (NULL != szConnStr && nBuffSize > 1 && strlen(m_szConnStr) > 0) {
		if (strlen(m_szConnStr) <= (unsigned int)nBuffSize) {
			strcpy(szConnStr, m_szConnStr);
			nResult = strlen(m_szConnStr);
		}
	}

	return nResult;
}

bool DatabaseCmd::SetConnStr(void) {								//设置连接数据库的字符串 
	bool bResult = true;
	try {
		GetPrivateProfileStringA("DATA_BASE", "ConnectStr", "", m_szConnStr, MAX_BUFF, ".\\Config.ini");
		if (strlen(m_szConnStr) < 1) 
		{
			char szUdlPath[] = { ".\\ConnectPath.udl" };
			WIN32_FIND_DATAA findData;
			if (INVALID_HANDLE_VALUE == FindFirstFileA(szUdlPath, &findData)) {
				FILE *hFile = fopen(szUdlPath, "a");
				if (NULL != hFile) {
					fclose(hFile);
				}
			}
			sprintf(m_szConnStr, "Provider=SQLOLEDB.1;Password=123abc;Persist Security Info=True;User ID=sa;Initial Catalog=Vehicle;Data Source=%s", szUdlPath);
		}
	}
	catch (...) {
		bResult = false;
	}

	return bResult;
}

bool DatabaseCmd::SetConnStr(char *szConnStr) {
	bool bResult = false;
	if (NULL != szConnStr && strlen(szConnStr) > 0) {
		strcpy(m_szConnStr, szConnStr);
		bResult = true;
	}
	return bResult;
}

void DatabaseCmd::CloseDB(void) {
	CloseRecord();
	try {
		if (NULL != m_pConn)
			m_pConn->Close();
	}
	catch (_com_error e) {
		char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
		sprintf(szLog, "关闭数据库连接错误:%s\n", (char *)(e.Description()));
		//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
	}
}

void DatabaseCmd::CloseRecord(void) {
	try {
		if (NULL != m_pRecord) {
			m_pRecord->Close();
			m_pRecord = NULL;
		}
	}
	catch (_com_error e) {
		char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
		sprintf(szLog, "关闭数据记录集错误:%s\n", (char *)(e.Description()));
		//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
	}
}

bool DatabaseCmd::BindingRecord(CADORecordBinding *RsObject, char *szSQLStr)
{
	bool bResult = false;

	CloseRecord();
	if (SelectSQL(szSQLStr)) {
		try {
			IADORecordBindingPtr picRs(m_pRecord);
			if (!FAILED(picRs->BindToRecordset(RsObject)))
				bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf(szLog, "绑定记录集错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}

	return bResult;
}

bool DatabaseCmd::IsRecordEOF()
{
	bool bResult = true;
	if (NULL != m_pRecord) {
		if (!m_pRecord->adoEOF)
			bResult = false;
	}
	return bResult;
}

bool DatabaseCmd::IsRecordBOF()
{
	bool bResult = true;
	if (NULL != m_pRecord) {
		if (!m_pRecord->adoBOF)
			bResult = false;
	}
	return bResult;
}

bool DatabaseCmd::RecordMoveNext()
{
	bool bResult = false;
	if (NULL != m_pRecord) {
		if (!m_pRecord->adoEOF) {
			try {
				m_pRecord->MoveNext();
				bResult = true;
			}
			catch (_com_error e) {
				char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
				sprintf(szLog, "RecordMoveNext错误:%s\n", (char *)(e.Description()));
				//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
			}
		}
	}
	return bResult;
}

bool DatabaseCmd::RecordMovePrevious()
{
	bool bResult = false;
	if (NULL != m_pRecord) {
		if (!m_pRecord->adoBOF) {
			try {
				m_pRecord->MovePrevious();
				bResult = true;
			}
			catch (_com_error e) {
				char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
				sprintf(szLog, "RecordMovePrevious错误:%s\n", (char *)(e.Description()));
				//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
			}
		}
	}
	return bResult;
}

bool DatabaseCmd::RecordMoveFirst()
{
	bool bResult = false;
	if (NULL != m_pRecord) {
		try {
			m_pRecord->MoveFirst();
			bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf(szLog, "RecordMoveFirst错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::RecordMoveLast()
{
	bool bResult = false;
	if (NULL != m_pRecord) {
		try {
			m_pRecord->MoveLast();
			bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf(szLog, "RecordMoveLast错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}

	return bResult;
}

bool DatabaseCmd::BeginTrans()
{
	bool bResult = false;
	if (NULL != m_pConn) {
		try {
			m_pConn->BeginTrans();
			bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf(szLog, "BeginTrans错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}

	return bResult;
}

bool DatabaseCmd::CommitTrans()
{
	bool bResult = false;
	if (NULL != m_pConn) {
		try {
			m_pConn->CommitTrans();
			bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf(szLog, "CommitTrans错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}

	return bResult;
}

bool DatabaseCmd::RollbackTrans()
{
	bool bResult = false;
	if (NULL != m_pConn) {
		try {
			m_pConn->RollbackTrans();
			bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf(szLog, "RollbackTranst错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}

	return bResult;
}
