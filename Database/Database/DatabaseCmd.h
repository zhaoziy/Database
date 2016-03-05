#if !defined(AFX_MYDBWORK_H__D777F369_68E5_4FA3_8198_6048A5DE7708__INCLUDED_)
#define AFX_MYDBWORK_H__D777F369_68E5_4FA3_8198_6048A5DE7708__INCLUDED_

#if _MSC_VER >1000
#pragma once
#endif // _MSC_VER> 1000

#pragma warning(disable:4146)
#import "msado15.dll" rename("EOF", "adoEOF"), rename("BOF", "adoBOF")
#pragma warning(default:4146)
using namespace ADODB;

#include <icrsint.h>
#include <string>
using namespace std;
#define MAX_BUFF 260

class DatabaseCmd
{
public:
	DatabaseCmd();
	~DatabaseCmd();

public:
	bool	BindingRecord(CADORecordBinding * RsObject, char *szSQLStr);
	bool	ConnDB(void);								//�������ݿ�
	int GetConnStr(char *szConnStr, int nBuffSize);	//����������ݿ���ַ��� 
	bool	SetConnStr(void);								//�����������ݿ���ַ���       
	bool	SetConnStr(char *szConnStr);					//�����������ݿ���ַ���       
	bool	SelectSQL(const char *szSQL);				//ִ��select���
	bool	ExecuteSQL(const char *szSQLStr, long &nRefreshNum);
	void	CloseDB(void);								//�رռ�¼�������Ӷ���	
	void CloseRecord(void);

public:
	bool BeginTrans();				//����һ�������൱�ڽ����ع���־
	bool CommitTrans();				//�ύBeginTrans֮�����е��޸�
	bool RollbackTrans();			//ȡ��BeginTrans֮�����еĲ���
	bool RecordMoveLast();
	bool RecordMoveFirst();
	bool RecordMovePrevious();
	bool RecordMoveNext();
	bool IsRecordBOF();
	bool IsRecordEOF();

	bool	CollectMsg(const char *szColumnName, long	&lTemp);
	bool	CollectMsg(const char *szColumnName, BYTE &btTemp);
	bool	CollectMsg(const char *szColumnName, DWORD &dwTemp);
	bool	CollectMsg(const char *szColumnName, UINT &iTemp);
	bool	CollectMsg(const char *szColumnName, int &iTemp);
	bool	CollectMsg(const char *szColumnName, float &fTemp);
	bool	CollectMsg(const char *szColumnName, double &dbTemp);
	bool	CollectMsg(const char *szColumnName, char &chTemp);
	bool	CollectMsg(const char *szColumnName, char *szBuff, int nBuffSize);
	bool CollectMsg(const char *szColumnName, string &szBuff);

	bool	CollectMsg(ULONG nIndex, long	&lTemp);
	bool	CollectMsg(ULONG nIndex, BYTE &btTemp);
	bool	CollectMsg(ULONG nIndex, DWORD &dwTemp);
	bool	CollectMsg(ULONG nIndex, UINT &iTemp);
	bool	CollectMsg(ULONG nIndex, int &iTemp);
	bool	CollectMsg(ULONG nIndex, float &fTemp);
	bool	CollectMsg(ULONG nIndex, double &dbTemp);
	bool	CollectMsg(ULONG nIndex, char &chTemp);
	bool	CollectMsg(ULONG nIndex, char *szBuff, int nBuffSize);

private:
	char m_szConnStr[MAX_BUFF];

private:
	_ConnectionPtr m_pConn;
	_RecordsetPtr  m_pRecord;
	_CommandPtr    m_pCommand;
	_ParameterPtr  m_pParameter;
};


#endif //!defined(AFX_MYDBWORK_H__D777F369_68E5_4FA3_8198_6048A5DE7708__INCLUDED_)