using System;
using System.Collections.Generic;

namespace CompanyWebPage.Log
{
    public interface IActionLogger
    {
        /// <summary>
        /// Should be used to log information about every actions call.
        /// </summary>
        /// <param name="controllerName">Name of controller which action is logged.</param>
        /// <param name="actionName">Name of the action which is logged.</param>
        /// <param name="actionParameters">Action parameters.</param>
        void Log(string controllerName, string actionName, IList<ActionParameter> actionParameters);
    }
}
