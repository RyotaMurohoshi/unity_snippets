using UnityEngine;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;

public class ShowMethod : MonoBehaviour
{
    void Start()
    {
        var info = new AssemblyDebugInfo("UnityEngine.dll");
        Debug.Log(JsonUtility.ToJson(info, true));
    }
}

[Serializable]
class AssemblyDebugInfo
{
    public string AssemblyName;
    public List<TypeDebugInfo> Types;

    public AssemblyDebugInfo(string assemblyName)
    {
        var assembly = Assembly.Load(assemblyName);
        AssemblyName = assembly.FullName;
        Types = assembly
            .GetTypes()
            .Where(it => it.IsPublic)
            .Select(it => new TypeDebugInfo(it))
            .ToList();
    }
}

[Serializable]
class TypeDebugInfo
{
    public string Name;
    public List<ConstructorDebugInfo> Constructors;
    public List<MethodDebugInfo> Methods;

    private static readonly BindingFlags Flags = BindingFlags.Instance
        | BindingFlags.Static
        | BindingFlags.DeclaredOnly
        | BindingFlags.Public;

    public TypeDebugInfo(Type type)
    {
        Name = type.FullName;
        Constructors = type.GetConstructors().Select(it => new ConstructorDebugInfo(it)).ToList();
        Methods = type.GetMethods(Flags).Select(it => new MethodDebugInfo(it)).ToList();
    }
}

[Serializable]
class ConstructorDebugInfo
{
    public List<string> ParameterTypeNames;

    public ConstructorDebugInfo(ConstructorInfo constructorInfo)
    {
        ParameterTypeNames = constructorInfo
            .GetParameters()
            .Select(it => it.ParameterType.Name)
            .ToList();
    }
}

[Serializable]
class MethodDebugInfo
{
    public string MethodName;
    public string ReturnTypeName;
    public List<string> ParameterTypeNames;
    public bool IsStatic;

    public MethodDebugInfo(MethodInfo methodInfo)
    {
        MethodName = methodInfo.Name;
        ReturnTypeName = methodInfo.ReturnType.Name;
        ParameterTypeNames = methodInfo.GetParameters().Select(it => it.ParameterType.Name).ToList();
        IsStatic = methodInfo.IsStatic;
    }
}
