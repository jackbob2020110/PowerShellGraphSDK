using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;


namespace BC.PowerShellGraphSDK.PowerShellCmdlets
{
    /// <summary>
    /// 获取用户
    /// </summary>
    [Cmdlet("Get", "Users", DefaultParameterSetName = @"Search")]
    [ODataType("microsoft.graph.user")]
    [ResourceTypePropertyName("groupODataType")]
    [Alias("Get-AADUser")]
    public class Get_Users : GetOrSearchCmdlet
    {
        /// <summary>
        /// 
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = @"Get", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.user&quot; object in the &quot;groups&quot; collection.")]
        public System.String UserId { get; set; }


        internal override System.String GetResourcePath()
        {
            return $"users/{UserId ?? string.Empty}";
        }

        internal override string GetSchemaVersion()
        {
            return this.SchemaVersion;
        }
    }

    [Cmdlet("New", "Users", ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = @"microsoft.graph.user")]
    [ODataType("microsoft.graph.user")]
    [ResourceTypePropertyName("groupODataType")]
    [Alias("New-AADGroup")]
    public class New_Users : PostCmdlet
    {
        /// <summary>
        ///     <para type="description">用户唯一标识.</para>
        /// </summary>
        [Selectable]
        [Expandable]
        [IdParameter]
        [ResourceIdParameter]
        public System.String UserID { get; set; }

        /// <summary>
        ///     <para type="description">显示名.</para>
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String displayName { get; set; }

 
        /// <summary>
        ///     <para type="description">是否启用账号.</para>
        /// </summary>
        [ODataType("Edm.Boolean")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.Boolean accountEnabled { get; set; }

        /// <summary>
        ///     <para type="description">别名</para>
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String mailNickname { get; set; }

        /// <summary>
        /// 用户主体名称
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String userPrincipalName { get; set; }

             /// <summary>
        ///     <para type="description">The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.</para>
        ///     <para type="description">This property is on the &quot;microsoft.graph.user&quot; type.</para>
        /// </summary>
        [ODataType("graph.passwordProfile")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.")]
        public System.Collections.Hashtable passwordProfile { get; set; }

        internal override System.String GetResourcePath()
        {
            return $"users/{UserID}"; 
        }
    }


}
