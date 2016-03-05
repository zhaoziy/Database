#include "stdafx.h"
#include "DatabaseCmd.h"
_COM_SMARTPTR_TYPEDEF(IADORecordBinding, __uuidof(IADORecordBinding));

DatabaseCmd::DatabaseCmd()
{
	m_pConn = NULL;
	m_pRecord = NULL;

	char ConnectStr[] = "Provider=SQLOLEDB.1;Password=123abc;Persist Security Info=True;User ID=sa;Initial Catalog=Vehicle;Data Source=.";

	if (strlen(ConnectStr) > 0) {}

	SetConnStr(ConnectStr);

	HRESULT hr = CoInitialize(NULL);

	if (FAILED(hr)) {}
}

DatabaseCmd::~DatabaseCmd()
{
	CoUninitialize();
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, long	&lTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			lTemp = RusultGet.lVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, BYTE &btTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			btTemp = RusultGet.bVal;
			bResult = true;
		}
		catch (_com_error e) {
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, DWORD &dwTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			dwTemp = RusultGet.ulVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, UINT &iTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			iTemp = RusultGet.ulVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, int &iTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			iTemp = RusultGet.intVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, float &fTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			fTemp = RusultGet.fltVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, double &dbTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			dbTemp = RusultGet.dblVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, char &chTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			chTemp = char(RusultGet.bstrVal[0]);
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, char *szBuff, int nBuffSize)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			WideCharToMultiByte(CP_ACP, 0, RusultGet.bstrVal, -1, szBuff, nBuffSize, NULL, NULL);
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(const char *szColumnName, string &szBuff)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column(szColumnName);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;

			if (RusultGet.vt == (VT_ARRAY | VT_UI1))
			{
				char *pTemp =NULL;
				SafeArrayAccessData(RusultGet.parray, (void **)&pTemp);
				szBuff = pTemp;
			}
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, long	&lTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			lTemp = RusultGet.lVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, BYTE &btTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			btTemp = RusultGet.bVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, DWORD &dwTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			dwTemp = RusultGet.ulVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, UINT &iTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			iTemp = RusultGet.ulVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, int &iTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			iTemp = RusultGet.intVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, float &fTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			fTemp = RusultGet.fltVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, double &dbTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			dbTemp = RusultGet.dblVal;
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, char &chTemp)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			chTemp = char(RusultGet.cVal);
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::CollectMsg(ULONG nIndex, char *szBuff, int nBuffSize)
{
	bool bResult = false;
	if (adStateClosed != m_pRecord->State)
	{
		try
		{
			_variant_t Column((long)nIndex);
			_variant_t RusultGet = m_pRecord->Fields->GetItem(Column)->Value;
			WideCharToMultiByte(CP_ACP, 0, RusultGet.bstrVal, -1, szBuff, nBuffSize, NULL, NULL);
			bResult = true;
		}
		catch (_com_error e)
		{
			char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
			sprintf_s(szLog, MAX_BUFF, "%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

bool DatabaseCmd::ConnDB(void) {
	bool bResult = false;
	if (NULL == m_pConn || adStateClosed == m_pConn->State)
	{
		if (strlen(m_szConnStr) > 0)
		{
			try
			{   //Connecting
				if (!FAILED(m_pConn.CreateInstance(_uuidof(Connection))))
				{ //设置连接超时时间
					m_pConn->CommandTimeout = 30;		//in seconds
					if (!FAILED(m_pConn->Open((_bstr_t)(m_szConnStr), "", "", adModeUnknown)))
						bResult = true;
				}
			}
			catch (_com_error e)
			{
				char szLog[MAX_BUFF]; memset(szLog, 0, MAX_BUFF);
				sprintf_s(szLog, MAX_BUFF, "连接数据库错误:%s\n", (char *)(e.Description()));
				//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
			}
		}
	}
	return bResult;
}

bool DatabaseCmd::SelectSQL(const char *szSQL)
{
	bool bResult = false;
	if (strlen(szSQL) > 0 && strlen(m_szConnStr) > 0)
	{
		if (NULL != m_pRecord/* || adStateClosed != m_pRecord->State*/)
			m_pRecord->Close();
		try
		{
			if (!FAILED(m_pRecord.CreateInstance(__uuidof(Recordset))))
			{
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
			sprintf_s(szLog, MAX_BUFF, "执行SQL查询命令错误:%s[%s]", (char *)(e.Description()), szSQL);
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

//nRefreshNum受影响的记录数
bool DatabaseCmd::ExecuteSQL(const char *szSQLStr, long &nRefreshNum)
{
	bool bResult = false;
	if (strlen(szSQLStr) > 0)
	{
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
			sprintf_s(szLog, MAX_BUFF, "执行SQL命令错误:%s[%s]", (char *)(e.Description()), szSQLStr);
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}
	return bResult;
}

int DatabaseCmd::GetConnStr(char *szConnStr, int nBuffSize)
{
	int nResult = 0;
	if (NULL != szConnStr && nBuffSize > 1 && strlen(m_szConnStr) > 0)
	{
		if (strlen(m_szConnStr) <= (unsigned int)nBuffSize)
		{
			strcpy_s(szConnStr, MAX_BUFF, m_szConnStr);
			nResult = (int)strlen(m_szConnStr);
		}
	}
	return nResult;
}

bool DatabaseCmd::SetConnStr(void)
{								//设置连接数据库的字符串 
	bool bResult = true;
	try
	{
		GetPrivateProfileStringA("DATA_BASE", "ConnectStr", "", m_szConnStr, MAX_BUFF, ".\\Config.ini");
		if (strlen(m_szConnStr) < 1) {
			char szUdlPath[] = { ".\\Test.udl" };
			WIN32_FIND_DATAA findData;
			if (INVALID_HANDLE_VALUE == FindFirstFileA(szUdlPath, &findData))
			{
				FILE *hFile = NULL; //fopen(szUdlPath, "a");
				fopen_s(&hFile, szUdlPath, "a");
				if (NULL != hFile)
				{
					fclose(hFile);
				}
			}
			sprintf_s(m_szConnStr, MAX_BUFF, "File Name=%s", szUdlPath);
		}
	}
	catch (...)
	{
		bResult = false;
	}
	return bResult;
}

bool DatabaseCmd::SetConnStr(char *szConnStr)
{
	bool bResult = false;
	if (NULL != szConnStr && strlen(szConnStr) > 0)
	{
		strcpy_s(m_szConnStr, MAX_BUFF, szConnStr);
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
		sprintf_s(szLog, MAX_BUFF, "关闭数据库连接错误:%s\n", (char *)(e.Description()));
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
		sprintf_s(szLog, MAX_BUFF, "关闭数据记录集错误:%s\n", (char *)(e.Description()));
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
			sprintf_s(szLog, MAX_BUFF, "绑定记录集错误:%s\n", (char *)(e.Description()));
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
				sprintf_s(szLog, MAX_BUFF, "RecordMoveNext错误:%s\n", (char *)(e.Description()));
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
				sprintf_s(szLog, MAX_BUFF, "RecordMovePrevious错误:%s\n", (char *)(e.Description()));
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
			sprintf_s(szLog, MAX_BUFF, "RecordMoveFirst错误:%s\n", (char *)(e.Description()));
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
			sprintf_s(szLog, MAX_BUFF, "RecordMoveLast错误:%s\n", (char *)(e.Description()));
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
			sprintf_s(szLog, MAX_BUFF, "BeginTrans错误:%s\n", (char *)(e.Description()));
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
			sprintf_s(szLog, MAX_BUFF, "CommitTrans错误:%s\n", (char *)(e.Description()));
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
			sprintf_s(szLog, MAX_BUFF, "RollbackTranst错误:%s\n", (char *)(e.Description()));
			//m_WriteLog.WriteLog(szLog, strlen(szLog), LOG_ERR);
		}
	}

	return bResult;
}
