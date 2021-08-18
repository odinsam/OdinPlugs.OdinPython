using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdinPlugs.OdinPython.Test.dbContext
{
    public class Report_DbModel
    {
        [Key]
        public long Id { get; set; }
        public long PassportId { get; set; }
        [Required] [StringLength(50)] public string PassportName { get; set; }
        public int ExaminationProject { get; set; }
        public int ExaminationSourceType { get; set; }
        [Required] [StringLength(100)] public string ExaminationProjectName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string ExaminationExtend { get; set; }

        public int ExaminationSubProject { get; set; }

        [StringLength(100)] [Required] public string ExaminationSubProjectName { get; set; } = string.Empty;
        public long ExaminationOrganizationId { get; set; }
        [Required] [StringLength(100)] public string ExaminationOrganizationName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string DeviceId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string DeviceName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string PatientId { get; set; }

        [Required] [StringLength(50)] public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public int PatientAgeUnit { get; set; }
        public int PatientGender { get; set; }
        public int PatientIdentityType { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PatientIdentityNo { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string PatientIdCard { get; set; }

        [Column(TypeName = "datetime")] public DateTime UploadTime { get; set; }
        public long ExaminationDoctorId { get; set; }
        [Required] [StringLength(50)] public string ExaminationDoctorName { get; set; }
        public long? ApplyDoctorId { get; set; }
        [StringLength(50)] public string ApplyDoctorName { get; set; }
        [Column(TypeName = "datetime")] public DateTime? ApplyTime { get; set; }
        public long? UrgentDoctorId { get; set; }
        [StringLength(50)] public string UrgentDoctorName { get; set; }
        [Column(TypeName = "datetime")] public DateTime? UrgentTime { get; set; }
        public int? UrgentType { get; set; }
        public int? UrgentLevel { get; set; }
        [StringLength(50)] public string RejectDoctorName { get; set; }
        public long? RejectDoctorId { get; set; }
        [Column(TypeName = "datetime")] public DateTime? RejectTime { get; set; }
        public long? AcceptDoctorId { get; set; }
        [StringLength(50)] public string AcceptDoctorName { get; set; }
        [Column(TypeName = "datetime")] public DateTime? AcceptTime { get; set; }
        public long? DiagnosisDoctorId { get; set; }
        [StringLength(50)] public string DiagnosisDoctorName { get; set; }
        [Column(TypeName = "datetime")] public DateTime? DiagnosisTime { get; set; }
        public long? DiagnosisCenterId { get; set; }
        [StringLength(50)] public string DiagnosisCenterName { get; set; }
        public long? DiagnosisOrganizationId { get; set; }
        [StringLength(50)] public string DiagnosisOrganizationName { get; set; }
        public long? AuditDoctorId { get; set; }
        [StringLength(50)] public string AuditDoctorName { get; set; }
        [Column(TypeName = "datetime")] public DateTime? AuditTime { get; set; }
        public int ReportStatus { get; set; }
        public int InterfaceStatus { get; set; }
        public long TagId { get; set; }
        [Required] [StringLength(50)] public string TagName { get; set; }

        /// <summary>
        ///     诊断结论 0-未知，1-会诊，2-自诊断,3-归档
        /// </summary>
        public int DiagnosisDataSource { get; set; }

        /// <summary>
        ///     归档数据来源  0-默认，1-心电电生理，2- 采集中心/子系统归档，99-第三方归档
        /// </summary>

        public int ArchiveDataSource { get; set; }

        [Column(TypeName = "varchar(50)")] public string ApplyExaminationNo { get; set; }
        [Column(TypeName = "varchar(50)")] public string PatientSourceNo { get; set; }
        public int PatientSource { get; set; }
        public long AuditCenterId { get; set; }
        [Required] [StringLength(50)] public string AuditCenterName { get; set; }
        public long AuditOrganizationId { get; set; }
        [Required] [StringLength(50)] public string AuditOrganizationName { get; set; }
        public int ExaminationOrganizationLevel { get; set; }
        public int ExaminationOrganizationType { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RetrievedDoctorId { get; set; }

        [Required] [StringLength(50)] public string RetrievedDoctorName { get; set; }
        public long RetrievedOrganizationId { get; set; }
        [Required] [StringLength(50)] public string RetrievedOrganizationName { get; set; }
        [Column(TypeName = "datetime")] public DateTime? RetrievedTime { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RegisterCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string RegisterDoctorId { get; set; }

        [Required] [StringLength(50)] public string RegisterDoctorName { get; set; }
        [Required] [StringLength(50)] public string RegisterDepartment { get; set; }
        [Column(TypeName = "datetime")] public DateTime? AcceptAuditTime { get; set; }
        public long AcceptAuditDoctorId { get; set; }
        [Required] [StringLength(50)] public string AcceptAuditDoctorName { get; set; }
        public int AuditType { get; set; }
        [Column(TypeName = "datetime")] public DateTime? ApplyAuditTime { get; set; }
        [Required] [StringLength(100)] public string ExaminationDepartment { get; set; }
        [StringLength(20)] public string RejectReason { get; set; }
        [StringLength(50)] public string RejectReasonKey { get; set; }
        [StringLength(500)] public string RejectRemark { get; set; }
        public int? RejectType { get; set; }
        public long? ExaminationDepartmentId { get; set; }
        [StringLength(100)] public string ExaminationDescription { get; set; }
        [Column(TypeName = "datetime")] public DateTime? ExaminationTime { get; set; }
        public int? DeviceType { get; set; }

        public long? DiagnosticGroupId { get; set; }

        public long? AuditGroupId { get; set; }

        /// <summary>
        /// 检查科室联系方式
        /// </summary>
        [StringLength(50)]
        public string ExaminationDepartmentPhone { get; set; }

        /// <summary>
        /// 检查医生联系方式
        /// </summary>
        [StringLength(50)]
        public string ExaminationDoctorPhone { get; set; }
    }
}