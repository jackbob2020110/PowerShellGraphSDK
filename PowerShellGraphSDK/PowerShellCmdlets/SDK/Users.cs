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
    [ResourceTypePropertyName("userODataType")]
    //[Alias("Get-AADUser")]
    public class Get_Users : GetOrSearchCmdlet
    {

        /// <summary>
        /// <para type="description">The "$search" query option value.</para>
        /// </summary>
        [Parameter(ParameterSetName = GetOrSearchCmdlet.OperationName)]
        public string SearchString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Selectable]
        [IdParameter]
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = @"Get", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.user&quot; object in the &quot;groups&quot; collection.")]
        public System.String UserId { get; set; }

        

        [ODataType("Edm.Boolean")]
        [Selectable]
        public Boolean accountEnabled { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String surname { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String givenName { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        public System.String userPrincipalName { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String displayName { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String mailNickname { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        public System.String jobTitle { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String department { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public String officeLocation { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        public String[] businessPhones { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String mobilePhone { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String faxNumber { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        public System.String country { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String city { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        public System.String state { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String streetAddress { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        public System.String postalCode { get; set; }



        [ODataType("Edm.String")]
        [Selectable]
        public System.String mail { get; set; }


        

        [ODataType("Edm.String")]
        [Selectable]
        public System.String passwordPolicies { get; set; }


        [ODataType("microsoft.graph.assignedLicense")]
        [Selectable]
        [Expandable]
        public System.Object[] assignedLicenses { get; set; }

        [ODataType("microsoft.graph.assignedPlans")]
        [Selectable]
        [Expandable]
        public System.Object[] assignedPlans { get; set; }


        [ODataType("microsoft.graph.servicePlanInfo")]
        [Selectable]
        [Expandable]
        public System.Object[] provisionedPlans { get; set; }



        [ODataType("Edm.String")]
        [Selectable]
        public System.String preferredLanguage { get; set; }
        
        [ODataType("Edm.String")]
        [Selectable]
        public System.String usageLocation { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        public System.String userType { get; set; }

        [ODataType("Edm.DateTimeOffset")]
        [Selectable]
        [Sortable]
        public System.DateTimeOffset createdDateTime { get; set; }

        [ODataType("Edm.DateTimeOffset")]
        [Selectable]
        [Sortable]
        public System.DateTimeOffset deletedDateTime { get; set; }

        internal override System.String GetResourcePath()
        {
            return $"users/{UserId ?? string.Empty}";
        }

        internal override string GetSchemaVersion()
        {
            return this.SchemaVersion;
        }

        internal override IDictionary<string, string> GetUrlQueryOptions()
        {
            IDictionary<string, string> queryOptions = base.GetUrlQueryOptions();

           
            // Search
            if (!string.IsNullOrEmpty(this.SearchString))
            {
                string sb = $"userPrincipalName eq '{SearchString}' or startswith(userPrincipalName,'{SearchString}') or mailNickName eq '{SearchString}' or startswith(mailNickName,'{SearchString}')  or displayName eq '{SearchString}' or startswith(displayName,'{SearchString}') or department eq '{SearchString}' or startswith(department,'{SearchString}') or jobTitle eq '{SearchString}' or startswith(jobTitle,'{SearchString}') or mail eq '{SearchString}' or startswith(mail,'{SearchString}')";
                queryOptions.Add("$filter", sb);
            }

            
            return queryOptions;
        }
    }

    [Cmdlet("New", "Users", ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = @"microsoft.graph.user")]
    [ODataType("microsoft.graph.user")]
    [ResourceTypePropertyName("userODataType")]
    //[Alias("New-AADGroup")]
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
        ///     <para type="description">是否启用账号.</para>
        /// </summary>
        [ODataType("Edm.Boolean")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.Boolean accountEnabled { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.String surname { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.String givenName { get; set; }

        

        /// <summary>
        /// 用户主体名称
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String userPrincipalName { get; set; }

        /// <summary>
        ///     <para type="description">显示名.</para>
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String displayName { get; set; }


        /// <summary>
        ///     <para type="description">别名</para>
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String mailNickname { get; set; }

       
        /// <summary>
        ///     <para type="description">The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.</para>
        ///     <para type="description">This property is on the &quot;microsoft.graph.user&quot; type.</para>
        /// </summary>
        [ODataType("microsoft.graph.passwordProfile")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.")]
        public System.Object passwordProfile { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String jobTitle { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String department { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public String officeLocation { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public String[] businessPhones { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String mobilePhone { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String faxNumber { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String country { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String city { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String state { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String streetAddress { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String postalCode { get; set; }


        internal override System.String GetResourcePath()
        {
            return $"users/{UserID}"; 
        }
    }


    [Cmdlet("Update", "Users", ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = @"microsoft.graph.user")]
    [ODataType("microsoft.graph.user")]
    [ResourceTypePropertyName("userODataType")]
    //[Alias("New-AADGroup")]
    public class Update_Users : PatchCmdlet
    {
        /// <summary>
        ///     <para type="description">用户唯一标识.</para>
        /// </summary>
        [Selectable]
        [Expandable]
        [IdParameter]
        [ResourceIdParameter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.group&quot; object in the &quot;groups&quot; collection.")]
        public System.String UserID { get; set; }



        /// <summary>
        ///     <para type="description">是否启用账号.</para>
        /// </summary>
        [ODataType("Edm.Boolean")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.Boolean accountEnabled { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.String surname { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailEnabled&quot; property, of type &quot;Edm.Boolean&quot;.")]
        public System.String givenName { get; set; }



        /// <summary>
        /// 用户主体名称
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String userPrincipalName { get; set; }

        /// <summary>
        ///     <para type="description">显示名.</para>
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String displayName { get; set; }


        /// <summary>
        ///     <para type="description">别名</para>
        /// </summary>
        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String mailNickname { get; set; }


        /// <summary>
        ///     <para type="description">The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.</para>
        ///     <para type="description">This property is on the &quot;microsoft.graph.user&quot; type.</para>
        /// </summary>
        [ODataType("microsoft.graph.passwordProfile")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;visibility&quot; property, of type &quot;Edm.String&quot;.")]
        public System.Object passwordProfile { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String jobTitle { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String department { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public String officeLocation { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public String[] businessPhones { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String mobilePhone { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String faxNumber { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String country { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String city { get; set; }


        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String state { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String streetAddress { get; set; }

        [ODataType("Edm.String")]
        [Selectable]
        [Parameter(ParameterSetName = @"microsoft.graph.user", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;mailNickname&quot; property, of type &quot;Edm.String&quot;.")]
        public System.String postalCode { get; set; }

        internal override System.String GetResourcePath()
        {
            return $"users/{UserID}";
        }
    }

    /// <summary>
    ///     <para type="synopsis">Removes a &quot;microsoft.graph.group&quot; object.</para>
    ///     <para type="description">Removes a &quot;microsoft.graph.group&quot; object from the &quot;groups&quot; collection.</para>
    ///     <para type="description">Graph Call: DELETE ~/groups/groupId</para>
    /// </summary>
    /// <para type="link" uri="https://github.com/Microsoft/Intune-PowerShell-SDK">GitHub Repository</para>
    [Cmdlet("Remove", "Users", ConfirmImpact = ConfirmImpact.High)]
    [ODataType("microsoft.graph.user")]
    [ResourceTypePropertyName("userODataType")]
    //[Alias("Remove-AADGroup")]
    public class Remove_Users : DeleteCmdlet
    {
        /// <summary>
        ///     <para type="description">The ID for a &quot;microsoft.graph.group&quot; object in the &quot;groups&quot; collection.</para>
        /// </summary>
        [Selectable]
        [Expandable]
        [IdParameter]
        [ResourceIdParameter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.group&quot; object in the &quot;groups&quot; collection.")]
        public System.String userId { get; set; }

        internal override System.String GetResourcePath()
        {
            return $"users/{userId}";
        }
    }
}
