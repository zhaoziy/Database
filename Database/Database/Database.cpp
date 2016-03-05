// Database.cpp : 定义控制台应用程序的入口点。
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
	char *szSQL = "select Data from [VehicleGeoInfo] where 版本 = 5 and Ext = 'TMPLT'";
	cmd.SelectSQL(szSQL);
	while (!cmd.IsRecordEOF()) {//判断是否到了记录结尾
		string btTemp;
		cmd.CollectMsg("Data", btTemp);//第一个参数，传列名

		ofstream fileOut("d:\\writefile.txt", ios::app);
		fileOut << btTemp << endl;
		fileOut.close();
		
		cmd.RecordMoveNext();//移动到下一个记录
	}
	cmd.CloseRecord();//关闭记录集
    return 0;
}

