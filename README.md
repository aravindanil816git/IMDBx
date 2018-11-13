# IMDBx

Prerequisite : <b>.NET Core framework, Node JS, Visual Studio 17.</b>

Steps : Make the IMDBx_App(master) folder available in the local
<ul>
  <li>1.Use IMDBx_App --> SQLScripts --> Script. Run this script prior in SQL Server under a db name <b>'IMDBx'</b>.</li>
  <li>2. Open IMDBx_App --> IMDBx.csproj in Visual Studio.</li>
  <li>3. Open Models -- > IMDBxContext.cs and <i> replace variable 'connectionStr'[line:11] with your new connection string.</i></li>
  <li>4.Build the project. It takes a few minute.Once build is successful, run the project.(Edge Prefered)</li>
</ul>

Ref: https://www.omdbapi.com/
