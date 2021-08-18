import json
import time

def ConvertModel(value):
    if isinstance(value, str):
        pyModel = json.loads(value)
        return pyModel

def changeDate(dtStr):
    dtStr = dtStr.replace("T"," ").split(".")[0]
    return time.strptime(dtStr,"%Y-%m-%d %H:%M:%S")


def AecgFilterModel(filterLst,filterRelationLst):
    # print type([105,"sdf"]) is not list
    # expression = ''
    result = ''
    count = len(filterLst)
    index = 0
    for item in filterLst:
        # 判断是否是 区间范围规则
        if item.IsRange:
            # 判断是否是日期类型
            if item.IsDateTime:
                # 日期类型区间
                # expression += "("+str(eval("changeDate(\""+str(item.MinDate)+"\")")) + " " + str(item.Op.split(" ")[0]) + " " + str(eval("changeDate(model[\""+item.Key+"\"])"))+ " " + str(item.Op.split(" ")[1]) + " " + str(eval("changeDate(\""+str(item.MaxDate)+"\")"))+")"
                result += "("+"changeDate(\""+str(item.MinDate)+"\")" + " " + str(item.Op.split(" ")[0]) + " " + "changeDate(model[\""+item.Key+"\"])"+ " " + str(item.Op.split(" ")[1]) + " " +"changeDate(\""+str(item.MaxDate)+"\")"+")"
            else:
                # number 类型区间
                # expression += "("+str(item.MinNumber)+ " " + str(item.Op.split(" ")[0]) + " " + str(eval("model[\""+item.Key+"\"]")) + " " + str(item.Op.split(" ")[1]) + " " +str(item.MaxNumber)+")"
                result += "("+str(item.MinNumber)+ " " + str(item.Op.split(" ")[0]) + " " + str("model[\""+item.Key+"\"]") + " " + str(item.Op.split(" ")[1]) + " " +str(item.MaxNumber)+")"
        else:
            # 判断是否是日期类型
            if item.IsDateTime:
                # 日期类型比较
                # expression += "("+str(eval("changeDate(model[\""+item.Key+"\"])"))+ " " + str(item.Op) + " " + str(eval("changeDate(\""+item.Value+"\")"))+")"
                result += "("+"changeDate(model[\""+item.Key+"\"])"+ " " + str(item.Op) + " " + "changeDate(\""+item.Value+"\")"+")"
            else:
                # 判断是否是  in 或者 not in 操作
                if item.Op == "in" or item.Op == "not in":
                    # 判断数据类型
                    if type(item.Value) is str:
                        # expression += "("+"\""+str(item.Value)+"\"" + " "+str(item.Op) + " " + str(eval("model[\""+item.Key+"\"]"))+")"
                        result += "("+"\""+str(item.Value)+"\""+" "+str(item.Op)+" model[\""+item.Key+"\"]"+")"
                    else:
                        if type(item.Value) is not list:
                            # expression += "("+str(item.Value)+" "+str(item.Op)+" "+"["+str(eval("model[\""+item.Key+"\"]"))+"]"+")"
                            result += "("+str(item.Value)+" "+str(item.Op)+" "+"[model[\""+item.Key+"\"]]"+")"
                        else:
                            # expression += "("+str(item.Value)+" "+str(item.Op)+" "+str(eval("model[\""+item.Key+"\"]"))+")"
                            result += "("+str(item.Value)+" "+str(item.Op)+" "+"model[\""+item.Key+"\"]"+")"
                else:
                    # 非日期类型比较
                    # expression +=  "("+str(eval("model[\""+item.Key+"\"]"))+" "+str(item.Op)+" "+str(item.Value)+")"
                    result += "("+"model[\""+item.Key+"\"]"+" "+str(item.Op)+" "+str(item.Value)+")"
        # 如果不是 最后一组filter规则，则添加对应的关系运算符
        if index+1 != count:
            # expression +=" "+str(filterRelationLst[index])+" "
            result += " "+str(filterRelationLst[index])+" "
        index += 1
    # print ("result is : ")
    # print (result)
    # print ("expression is : ")
    # print (expression)
    return result


def AecgPythonInvoker(model,result):
    return bool(eval(result))