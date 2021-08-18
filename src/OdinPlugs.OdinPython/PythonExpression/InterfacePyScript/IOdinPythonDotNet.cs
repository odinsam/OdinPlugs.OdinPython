using System.Collections.Generic;
using OdinPlugs.OdinPython.PythonExpression.Models;

namespace OdinPlugs.OdinPython.PythonExpression.InterfacePyScript
{
    public interface IOdinPythonDotNet
    {
        /// <summary>
        /// PyScript 脚本
        /// </summary>
        /// <value></value>
        string PyScript { get; set; }
        /// <summary>
        /// 获取PythonDotNet对象
        /// </summary>
        /// <returns></returns>
        IOdinPythonDotNet GetPythonDotNet();
        /// <summary>
        /// 获取pythonModel
        /// </summary>
        /// <param name="jsonModel">model的json字符串</param>
        /// <returns>获取pythonModel</returns>
        dynamic GetPythonModel(string jsonModel);

        /// <summary>
        /// 执行自定制脚本
        /// </summary>
        /// <param name="pyScript">脚本内容</param>
        /// <param name="methodName">方法名</param>
        /// <param name="args">方法参数 params</param>
        /// <returns>脚本返回值</returns>
        dynamic InvokerCustomScript(string pyScript, string methodName, params object[] args);
        /// <summary>
        /// 按照命中规则执行python脚本，执行调度匹配
        /// </summary>
        /// <param name="pythonModel">需要python格式对象</param>
        /// <param name="filter">命中规则</param>
        /// <returns>是否命中，true：命中  false：没有命中</returns>
        bool GetAnalysisResult(dynamic pythonModel, string filter);

        /// <summary>
        /// 按照前端规则，生成调度命中规则
        /// </summary>
        /// <param name="filterModels">命中规则集合</param>
        /// <returns>调度规则字符串</returns>
        string GenerateFilter(List<FilterModel> filterModels);
    }
}