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
	bool	ConnDB(void);								//连接数据库
	int GetConnStr(char *szConnStr, int nBuffSize);	//获得连接数据库的字符串 
	bool	SetConnStr(void);								//设置连接数据库的字符串       
	bool	SetConnStr(char *szConnStr);					//设置连接数据库的字符串       
	bool	SelectSQL(const char *szSQL);				//执行select语句
	bool	ExecuteSQL(const char *szSQLStr, long &nRefreshNum);
	void	CloseDB(void);								//关闭记录集、连接对象	
	void CloseRecord(void);

public:
	bool BeginTrans();				//启动一新事务，相当于建立回滚标志
	bool CommitTrans();				//提交BeginTrans之后所有的修改
	bool RollbackTrans();			//取消BeginTrans之后所有的操作
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