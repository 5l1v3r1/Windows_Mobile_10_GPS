How this work

Add script GPS folder project

add in .csproj this line before 

</Reference>
	<Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Device" /><!-- GET GPS -->
</ItemGroup>