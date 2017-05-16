﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GrubTime.Services
{
    public class OperationDescription
    {
        public ContractDescription Contract { get; private set; }
        public string MyFirstAction { get; private set; }
        public string ReplyAction { get; private set; }
        public string Name { get; private set; }
        public MethodInfo DispatchMethod { get; private set; }
        public bool IsOneWay { get; private set; }

        public OperationDescription(ContractDescription contract, MethodInfo operationMethod, OperationContractAttribute contractAttribute)
        {
            Contract = contract;
            Name = contractAttribute.Name ?? operationMethod.Name;
            MyFirstAction = contractAttribute.Action ?? $"{contract.Namespace.TrimEnd('/')}/{contract.Name}/{Name}";
            IsOneWay = contractAttribute.IsOneWay;
            ReplyAction = contractAttribute.ReplyAction;
            DispatchMethod = operationMethod;
        }
    }
}