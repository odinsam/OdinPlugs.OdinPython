using System;

namespace OdinPlugs.OdinPython.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            PythonTest pythonTest = new PythonTest();

            // 获取原始python调度脚本
            pythonTest.GetPythonScript();

            // 获取调度规则
            var filterStr = pythonTest.GetAnalysisFilter();

            // 获取 解析对象
            dynamic pythonModel = pythonTest.AnalysisModel();

            //解析对象返回命中结果
            bool result = pythonTest.GetAnalysisResult(pythonModel, filterStr);

            // 执行自定义脚本
            var customResult = pythonTest.InvokerCustomScript();
        }
    }
}
