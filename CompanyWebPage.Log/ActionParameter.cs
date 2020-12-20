using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyWebPage.Log
{
    /// <summary>
    /// Action parameter
    /// </summary>
    public class ActionParameter
    {
        /// <summary>
        /// Parameter name.
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// Parameter type.
        /// </summary>
        public Type ParameterType { get; set; }
        /// <summary>
        /// Parameter value.
        /// </summary>
        public object ParameterValue { get; set; }
    }
}
