// Database.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include <fstream>
#include <iostream>
#include "DatabaseCmd.h"
using namespace std;

int main()
{
	DatabaseCmd cmd;
	cmd.ConnDB();
	char *szSQL = "select Data from [VehicleGeoInfo] where �汾 = 5 and Ext = 'TMPLT'";
	cmd.SelectSQL(szSQL);
	while (!cmd.IsRecordEOF()) {//�ж��Ƿ��˼�¼��β
		string btTemp;
		cmd.CollectMsg("Data", btTemp);//��һ��������������

		ofstream fileOut("d:\\writefile.txt", ios::app);
		fileOut << btTemp << endl;
		fileOut.close();
		
		cmd.RecordMoveNext();//�ƶ�����һ����¼
	}
	cmd.CloseRecord();//�رռ�¼��
    return 0;
}

