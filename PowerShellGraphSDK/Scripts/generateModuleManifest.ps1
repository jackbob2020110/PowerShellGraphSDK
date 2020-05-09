param(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$ModuleName,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$OutputDirectory,

    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$MainModuleRelativePath
)

$OutputDirectory = $OutputDirectory | Resolve-Path
$modulePath = "$OutputDirectory/$ModuleName.psd1"

# Maintain a list of all the cmdlets, functions and aliases to export
$cmdlets = @()
$functions = @()
$aliases = @()
$variables = @()

# Get the version of the main module and use it to set the version of the overall module
$moduleVersion = "0.0.0.0"

Push-Location $OutputDirectory
try {
    # Normalize the path to the main module
    $mainModulePath = Get-ChildItem $MainModuleRelativePath -File | Resolve-Path -Relative

    # Create a single list of all modules
    $modulePaths = @()
    $modulePaths += $mainModulePath
    $nestedModules = Get-ChildItem -Include '*.psm1', '*.ps1' -Recurse -File | Resolve-Path -Relative
    if ($nestedModules) {
        $modulePaths += $nestedModules
    }

    # Collect module information
    foreach ($current in $modulePaths) {
        if (-Not $current.StartsWith('.\')) {
            throw "Provided paths must start with '.\', but '$current' does not"
        }
        if (-Not (Test-Path $current)) {
            throw "Module not found at '$current'. Does this path exist under '$OutputDirectory'?"
        }

        Write-Host "Including module: '$current'"

        # Get the module's information
        $info = Get-Module $current -ListAvailable

        # Get the module version from the main module
        if ($current -eq $mainModulePath)
        {
            $moduleVersion = $info.Version
        }

        # Get cmdlets
        $cmdlets += [string[]]$info.ExportedCmdlets.Keys

        # Get functions
        $functions += [string[]]$info.ExportedFunctions.Keys

        # Get aliases
        $aliases += [string[]]$info.ExportedAliases.Keys

        # Get Variables
        $variables += [string[]]$info.ExportedVariables.Keys
    }
} finally {
    Pop-Location
}

# Build the content of the generated manifest
$generateManifestArgs = @{
    Path = $modulePath

    # START PrivateData.PSData
        # Tags applied to this module. These help with module discovery in online galleries.
        Tags = @(
            'Microsoft',            
            'Graph',
            'PowerShell',
            'SDK'
        )

        # Flag to indicate whether the module requires explicit user acceptance
        # RequireLicenseAcceptance = $true

        # A URL to the license for this module.
        LicenseUri = 'https://github.com/xxx/MicrosoftGraph-PowerShell-SDK/blob/master/src/PowerShellGraphSDK/PowerShellModuleAdditions/LICENSE.txt'

        # A URL to the main website for this project.
        ProjectUri = 'https://github.com/xxx/MicrosoftGraph-PowerShell-SDK'

        # A URL to an icon representing this module.
        # IconUri = ''

        # ReleaseNotes of this module
        # ReleaseNotes = ''

        # External dependent modules of this module
        # ExternalModuleDependencies = ''
    # END PrivateData.PSData

    # Script module or binary module file associated with this manifest
    RootModule = $mainModulePath

    # Version number of this module.
    ModuleVersion = $moduleVersion

    # ID used to uniquely identify this module
    GUID = [guid]::NewGuid()

    # Author of this module
    Author = 'BC Corporation'

    # Company or vendor of this module
    CompanyName = 'BC Corporation'

    # Copyright statement for this module
    Copyright = '(c) 2020 BC. All rights reserved.'

    # Description of the functionality provided by this module
    Description = 'PowerShell SDK for BC MSGraph API'

    # Minimum version of the Windows PowerShell engine required by this module
    # PowerShellVersion = ''

    # Name of the Windows PowerShell host required by this module
    # PowerShellHostName = ''

    # Minimum version of the Windows PowerShell host required by this module
    # PowerShellHostVersion = ''

    # Minimum version of the .NET Framework required by this module
    # DotNetFrameworkVersion = ''

    # Minimum version of the common language runtime (CLR) required by this module
    # CLRVersion = ''

    # Processor architecture (None, X86, Amd64) required by this module
    # ProcessorArchitecture = ''

    # Modules that must be imported into the global environment prior to importing this module
    # RequiredModules = @()

    # Assemblies that must be loaded prior to importing this module
    # RequiredAssemblies = @()

    # Script files (.ps1) that are run in the caller's environment prior to importing this module
    # ScriptsToProcess = @()

    # Type files (.ps1xml) to be loaded when importing this module
    # TypesToProcess = @()

    # Format files (.ps1xml) to be loaded when importing this module
    # FormatsToProcess = @()

    # Functions to export from this module
    FunctionsToExport = '*' # $functions

    # Cmdlets to export from this module
    CmdletsToExport = '*' # $cmdlets

    # Variables to export from this module
    VariablesToExport = '*' # $variables

    # Aliases to export from this module
    AliasesToExport = '*' # $aliases

    # List of all modules packaged with this module
    # ModuleList = @()

    # List of all files packaged with this module
    # FileList = @()

    # Private data to pass to the module specified in RootModule/ModuleToProcess
    # PrivateData = ''

    # HelpInfo URI of this module
    # HelpInfoURI = ''

    # Default prefix for commands exported from this module. Override the default prefix using Import-Module -Prefix.
    # DefaultCommandPrefix = 'MSGraph'

    # Modules to import as nested modules of the module specified in RootModule/ModuleToProcess
    NestedModules = $nestedModules
}

New-ModuleManifest @generateManifestArgs