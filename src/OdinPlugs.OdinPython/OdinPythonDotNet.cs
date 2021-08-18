using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using OdinPlugs.OdinPython.PythonExpression.enums;
using OdinPlugs.OdinPython.PythonExpression.InterfacePyScript;
using OdinPlugs.OdinPython.PythonExpression.Models;

namespace OdinPlugs.OdinPython
{
    public class OdinPythonDotNet : IOdinPythonDotNet
    {
        public ScriptEngine Engine { get; set; }
        public ScriptScope Scope { get; set; }
        public ObjectOperations Ops { get; set; }
        public string PyScript { get; set; }
        public OdinPythonDotNet()
        {
            Engine = Python.CreateEngine();
            Scope = Engine.CreateScope();
            Ops = Engine.Operations;
            this.PyScript = Encoding.UTF8.GetString(Convert.FromBase64String(GetPythonContent()));
            Engine.Execute(PyScript, Scope);
        }
        public OdinPythonDotNet(string pyScript)
        {
            Engine = Python.CreateEngine();
            Scope = Engine.CreateScope();
            Ops = Engine.Operations;
            this.PyScript = pyScript;
            Engine.Execute(pyScript, Scope);
        }

        public IOdinPythonDotNet GetPythonDotNet()
        {
            IOdinPythonDotNet pythonDotNet = new OdinPythonDotNet();
            return pythonDotNet;
        }

        public dynamic GetPythonModel(string jsonModel)
        {
            Engine.Execute(PyScript, Scope);
            var ConvertModel_Method = this.Scope.GetVariable("ConvertModel");
            return this.Ops.Invoke(ConvertModel_Method, jsonModel);
        }
        /// <summary>
        /// 获取原始python脚本内容 base64格式
        /// </summary>
        /// <returns></returns>
        public static string GetPythonContent()
        {
            string pyScript = string.Empty;
            using (FileStream fileStream = new FileStream("pyScript/tf.py", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader stReader = new StreamReader(fileStream))
                {
                    pyScript = stReader.ReadToEnd();
                }
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(pyScript)); ;
        }
        public dynamic InvokerCustomScript(string pyScript, string methodName, params object[] args)
        {
            Engine = Python.CreateEngine();
            Scope = Engine.CreateScope();
            Ops = Engine.Operations;
            Engine.Execute(pyScript, Scope);
            var AecgPythonCustomInvoker = Scope.GetVariable(methodName);
            return Ops.Invoke(AecgPythonCustomInvoker, args);
        }

        public bool GetAnalysisResult(dynamic pythonModel, string filter)
        {
            var AecgPythonInvoker_Method = this.Scope.GetVariable("AecgPythonInvoker");
            dynamic result = this.Ops.Invoke(AecgPythonInvoker_Method, pythonModel, filter);
            return (bool)result;
        }

        public string GenerateFilter(List<FilterModel> filterModels)
        {
            List<FilterRelation> FilterRelations = new List<FilterRelation>();
            for (int i = 0; i < filterModels.Count; i++)
            {
                if (i != filterModels.Count - 1)
                    if (filterModels[i].FilterRelationOp != null)
                        FilterRelations.Add((FilterRelation)filterModels[i].FilterRelationOp);
                    else
                        throw new System.Exception("关系符与条件个数不符");
            }
            Engine.Execute(PyScript, Scope);
            var AecgFilterModel_Method = this.Scope.GetVariable("AecgFilterModel");
            dynamic result = this.Ops.Invoke(
                                AecgFilterModel_Method,
                                filterModels,
                                FilterRelations
                                );
            return result.ToString();
        }
    }
}