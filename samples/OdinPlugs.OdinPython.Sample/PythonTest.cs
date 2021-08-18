using System;
using System.Collections.Generic;
using System.Text;
using OdinPlugs.OdinPython.PythonExpression.enums;
using OdinPlugs.OdinPython.PythonExpression.InterfacePyScript;
using OdinPlugs.OdinPython.PythonExpression.Models;

namespace OdinPlugs.OdinPython.Sample
{
    public class PythonTest
    {
        /// <summary>
        /// 获取 IOdinPythonDotNet 对象
        /// </summary>
        /// <returns></returns>
        public IOdinPythonDotNet GetPythonDotNet()
        {
            IOdinPythonDotNet pythonDotNet = new OdinPythonDotNet();
            return pythonDotNet;
        }
        /// <summary>
        /// 获取 IOdinPythonDotNet 原始引擎对象
        /// </summary>
        /// <returns></returns>
        public IOdinPythonDotNet GetPythonDotNetEngine()
        {
            IOdinPythonDotNet pythonDotNet = new OdinPythonDotNet();
            return pythonDotNet;
        }
        /// <summary>
        /// 获取原始python调度脚本
        /// </summary>
        public void GetPythonScript()
        {
            System.Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(OdinPythonDotNet.GetPythonContent())));
        }

        /// <summary>
        /// 获取调度命中规则
        /// </summary>
        public string GetAnalysisFilter()
        {
            IOdinPythonDotNet pythonDotNet = GetPythonDotNet();
            var filter = new List<FilterModel>()
                {
                new FilterModel { Key = "Id", Value = 4963147285533195, Op = "==", FilterRelationOp = FilterRelation.and },
                    new FilterModel { Key = "PassportId", Value = 4576912185346304, Op = "==", FilterRelationOp = FilterRelation.and },
                    new FilterModel { Key = "ExaminationTime", MinDate = "2019-12-13 10:00:44", MaxDate = "2019-12-13 10:00:46", Op = "< <", IsDateTime = true, IsRange = true, FilterRelationOp = FilterRelation.and },
                    new FilterModel { Key = "DeviceType", MinNumber = 0, MaxNumber = 5, Op = "<= <", IsRange = true, FilterRelationOp = FilterRelation.and },
                    new FilterModel { Key = "DeviceType", Value = 3, Op = "in", FilterRelationOp = FilterRelation.and },
                    new FilterModel { Key = "ExaminationDoctorName", Value = "陈", MaxNumber = 5, Op = "not in" }
                };
            var filterStr = pythonDotNet.GenerateFilter(filter);
#if DEBUG
            System.Console.WriteLine($"调度命中规则:\r\n{filterStr}\r\n\r\n");
#endif
            return filterStr;
        }

        /// <summary>
        /// 获取 解析对象
        /// </summary>
        public dynamic AnalysisModel()
        {
            string strModel = "{ \"DeviceType\":1,\"PassportId\":4872536131099392,\"RejectType\":0,\"DiagnosisOrganizationName\":\"\",\"PatientId\":\"\",\"PatientAge\":66,\"DiagnosisCenterName\":\"\",\"ExaminationOrganizationId\":1234567899876662,\"RejectReason\":\"\",\"ExaminationProject\":1,\"AuditDoctorId\":0,\"ExaminationSubProjectName\":\"\",\"ArchiveDataSource\":0,\"AuditCenterName\":\"\",\"UrgentTime\":null,\"RetrievedDoctorId\":\"\",\"ExaminationOrganizationName\":\"测试四川检查中心\",\"DiagnosisCenterId\":0,\"ExaminationSubProject\":0,\"RejectDoctorName\":\"\",\"PatientSourceNo\":\"\",\"ExaminationDepartmentId\":4577170264088832,\"ExaminationOrganizationType\":0,\"DiagnosisDoctorName\":\"\",\"AuditDoctorName\":\"\",\"RetrievedOrganizationName\":\"\",\"ExaminationDoctorId\":4575985526229248,\"DiagnosisDoctorId\":0,\"AuditGroupId\":null,\"Id\":4963147285533195,\"InterfaceStatus\":0,\"AcceptAuditTime\":\"1800-01-01T00:00:00\",\"RetrievedOrganizationId\":0,\"ApplyExaminationNo\":\"\",\"ExaminationProjectName\":\"静息心电\",\"AuditTime\":\"1800-01-01T00:00:00\",\"DeviceName\":\"RAGE-18P\",\"TagId\":0,\"PatientName\":\"AT-10-49-05\",\"ExaminationDescription\":\"\",\"ExaminationDoctorName\":\"小花\",\"ApplyDoctorName\":\"小花\",\"ApplyDoctorId\":4575985526229248,\"RegisterCode\":\"\",\"AuditType\":0,\"ExaminationOrganizationLevel\":0,\"ApplyAuditTime\":\"1800-01-01T00:00:00\",\"TagName\":\"\",\"DiagnosisOrganizationId\":0,\"AuditCenterId\":0,\"AcceptTime\":\"1800-01-01T00:00:00\",\"ReportStatus\":4001,\"ExaminationDoctorPhone\":null,\"DiagnosisTime\":\"1800-01-01T00:00:00\",\"RegisterDoctorName\":\"\",\"RegisterDepartment\":\"\",\"AcceptDoctorId\":0,\"RejectTime\":\"1800-01-01T00:00:00\",\"ExaminationDepartment\":\"检查中心部门\",\"RetrievedTime\":\"1800-01-01T00:00:00\",\"PatientGender\":1,\"RejectDoctorId\":0,\"DiagnosticGroupId\":null,\"PatientSource\":1,\"AcceptAuditDoctorId\":0,\"RejectRemark\":\"\",\"AcceptAuditDoctorName\":\"\",\"ExaminationSourceType\":0,\"PatientIdCard\":\"\",\"UrgentDoctorId\":null,\"RejectReasonKey\":null,\"ExaminationTime\":\"2020-06-09T22:49:17\",\"UrgentType\":null,\"AcceptDoctorName\":\"\",\"UploadTime\":\"2020-06-10T11:57:27.833\",\"UrgentDoctorName\":null,\"UrgentLevel\":null,\"RetrievedDoctorName\":\"\",\"ApplyTime\":\"2020-06-10T11:57:27.883\",\"PatientAgeUnit\":0,\"PatientIdentityNo\":\"\",\"ExaminationDepartmentPhone\":null,\"AuditOrganizationName\":\"\",\"PatientIdentityType\":1,\"AuditOrganizationId\":0,\"DiagnosisDataSource\":0,\"DeviceId\":\"4872535896005376\",\"ExaminationExtend\":\"\",\"PassportName\":\"7ac7472c002c350f\",\"RegisterDoctorId\":\"\"}";
            IOdinPythonDotNet pythonDotNet = new OdinPythonDotNet();
            dynamic pythonModel = pythonDotNet.GetPythonModel(strModel);
            return pythonModel;
        }

        /// <summary>
        /// 解析对象返回命中结果
        /// </summary>
        /// <param name="pythonModel">pythonModel</param>
        /// <param name="filter">命中规则字符串</param>
        /// <returns>命中结果</returns>
        public bool GetAnalysisResult(dynamic pythonModel, string filter)
        {
            IOdinPythonDotNet pythonDotNet = GetPythonDotNet();
            dynamic python = AnalysisModel();
            string filterStr = GetAnalysisFilter();
            bool flag = pythonDotNet.GetAnalysisResult(python, filterStr);
#if DEBUG
            System.Console.WriteLine($"命中结果:\r\n{flag}\r\n\r\n");
#endif
            return flag;
        }

        /// <summary>
        /// 执行自定义脚本
        /// </summary>
        /// <returns></returns>
        public string InvokerCustomScript()
        {
            IOdinPythonDotNet pythonDotNet = GetPythonDotNet();
            var pyStr = "def PythonCustomInvoker(str):\r\n\tprint (str)\r\n\treturn 'result'";
            string result = pythonDotNet.InvokerCustomScript(pyStr, "PythonCustomInvoker", "param");
#if DEBUG
            System.Console.WriteLine($"自定义脚本执行结果:\r\n{result}\r\n\r\n");
#endif
            return result;
        }
    }
}