﻿

namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// The common behavior between all OData PowerShell SDK cmdlets that call OData functions that return a collection of entities.
    /// </summary>
    public abstract class FunctionReturningCollectionCmdlet : GetOrSearchCmdlet
    {
        // TODO: Allow dynamic parameters once the generator supports them
        /// <summary>
        /// Creates a new <see cref="FunctionReturningCollectionCmdlet"/>.
        /// </summary>
        public FunctionReturningCollectionCmdlet()
        {
            this.DynamicParameters = null;
        }
    }
}