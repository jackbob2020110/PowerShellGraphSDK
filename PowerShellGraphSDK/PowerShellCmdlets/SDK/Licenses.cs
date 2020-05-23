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
    [Cmdlet("Get", "SKUs", DefaultParameterSetName = @"Search")]
    [ODataType("graph.assignedLicense")]
    [ResourceTypePropertyName("LicenseODataType")]
    [Alias("Get-Sku")]
    public class Get_SKus : GetOrSearchCmdlet
    {
        /// <summary>
        /// 获取SKU信息
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter(ParameterSetName = @"Get", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.user&quot; object in the &quot;groups&quot; collection.")]
        public string UserId { get; set; }


        internal override System.String GetResourcePath()
        {
            return $"subscribedSkus";
        }

        internal override string GetSchemaVersion()
        {
            return this.SchemaVersion;
        }
    }


    ///// <summary>
    ///// 
    ///// </summary>
    //[Cmdlet("Add", "UserLicense", ConfirmImpact = ConfirmImpact.Low, DefaultParameterSetName = @"microsoft.graph.directoryObject")]
    //[ODataType("microsoft.graph.directoryObject")]
    //[ResourceTypePropertyName("directoryODataType")]
    ////[Alias("Add-UserLicense")]
    //public class Add_UserLicense : PostCmdlet
    //{
    //    [Selectable]
    //    [Expandable]
    //    [IdParameter]
    //    [ResourceIdParameter]
    //    [ValidateNotNullOrEmpty]
    //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID for a &quot;microsoft.graph.managedDevice&quot; object in the &quot;managedDevices&quot; collection.")]
    //    public string userId { get; set; }

    //    /// <summary>
    //    ///     <para type="description">分配许可</para>
    //    /// </summary>
    //    [ODataType("microsoft.graph.assignedLicense")]
    //    [Selectable]
    //    [AllowEmptyCollection]
    //    [Parameter(ParameterSetName = @"microsoft.graph.directoryObject", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
    //    [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
    //    public System.Object[] assignedLicenses { get; set; }

    //    /// <summary>
    //    ///     <para type="description">移除许可.</para>
    //    /// </summary>
    //    [ODataType("microsoft.graph.assignedLicense")]
    //    [Selectable]
    //    [AllowEmptyCollection]
    //    [Parameter(ParameterSetName = @"microsoft.graph.directoryObject", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
    //    [Parameter(ParameterSetName = @"ManualTypeSelection", ValueFromPipelineByPropertyName = true, HelpMessage = @"The &quot;displayName&quot; property, of type &quot;Edm.String&quot;.")]
    //    public System.Object[] removeLicenses { get; set; }


    //    internal override string GetResourcePath()
    //    {
    //        return $"users/{userId}/assignLicense";
    //    }
    //}

    //public class AssignedLicense
    //{
    //    public List<string> DisabledPlans
    //    {
    //        get;
    //        set;
    //    }

    //    public string SkuId
    //    {
    //        get;
    //        set;
    //    }
    //}

    //public class AssignedLicenses
    //{
    //    public List<AssignedLicense> AddLicenses
    //    {
    //        get;
    //        set;
    //    }

    //    public List<string> RemoveLicenses
    //    {
    //        get;
    //        set;
    //    }
    //}
}
