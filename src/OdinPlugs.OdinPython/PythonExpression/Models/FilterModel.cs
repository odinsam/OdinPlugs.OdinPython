using System;
using OdinPlugs.OdinPython.PythonExpression.enums;

namespace OdinPlugs.OdinPython.PythonExpression.Models
{
    /// <summary>
    /// 过滤模型
    /// </summary>
    public class FilterModel
    {
        /// <summary>
        /// 过滤关键字
        /// </summary>
        /// <value></value>
        public string Key { get; set; }
        /// <summary>
        /// 关键字对应的值
        /// </summary>
        /// <value></value>
        public Object Value { get; set; }
        /// <summary>
        /// 最大值 - 用于范围过滤且是number类型 int float double 都可以使用
        /// </summary>
        /// <value></value>
        public double MaxNumber { get; set; }
        /// <summary>
        /// 最小值 - 用于范围过滤且是number类型 int float double 都可以使用
        /// </summary>
        /// <value></value>
        public double MinNumber { get; set; }
        /// <summary>
        /// 最大日期 - 用于范围过滤且是日期类型 注意: 需要是日期的 string 格式 yyyy-dd-MM HH:mm:ss
        /// </summary>
        /// <value></value>
        public string MaxDate { get; set; }
        /// <summary>
        /// 最小日期 - 用于范围过滤且是日期类型 注意: 需要是日期的 string 格式 yyyy-dd-MM HH:mm:ss
        /// </summary>
        /// <value></value>
        public string MinDate { get; set; }
        /// <summary>
        /// 比较运算符 - 可以是 &amp;gt; &amp;lt; &amp;lt;= &amp;gt;= in not in == no 等运算符
        /// </summary>
        /// <value></value>
        public string Op { get; set; }
        /// <summary>
        /// 是否是范围过滤 默认-false
        /// </summary>
        /// <value></value>
        public bool IsRange { get; set; } = false;
        /// <summary>
        /// 是否是日期类型比较 默认-false
        /// </summary>
        /// <value></value>
        public bool IsDateTime { get; set; } = false;
        /// <summary>
        /// number类型范围比较
        /// </summary>
        /// <value></value>
        public double[] NumberRange { get; set; }

        public FilterRelation? FilterRelationOp { get; set; } = null;
    }
}