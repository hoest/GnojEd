GnojEd
===
Initial commit, so nothing much yet.

I'm planning to create a simple CMS or Blogengine, based on [JessicaFx][1] and
[Simple.Data][2] in C#. I want to make it work in a Medium Trust ASP.NET
environment, so you can use it at any ISP with a [MySQL database][3].

A web.config needs to be added (in GnojEd.Site) to use this site:

    <?xml version="1.0"?>
    <configuration>
      <connectionStrings>
        <add name="DefaultDatabase"
             connectionString="Server=***;Uid=***;Database=***;Password=***;Pooling=True"
             providerName="MySql.Data.MySqlClient" />
      </connectionStrings>
      <system.web>
        <customErrors mode="Off" />
        <compilation debug="true" targetFramework="4.0" />
        <authentication mode="Forms" />
      </system.web>
    </configuration>

Follow this project on [Twitter][4].

[1]: http://www.jessicafx.org/ "JessicaFx"
[2]: https://github.com/markrendle/Simple.Data "Simple.Data"
[3]: http://www.mysql.com/ "MySQL"
[4]: http://twitter.com/GnojEdDev "GnojEd on Twitter"