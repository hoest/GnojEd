<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">
  <xsl:import href="include.xsl"/>

  <xsl:output method="xml" version="1.0" encoding="utf-8"
              doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN"
              doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"
              indent="no"/>

  <xsl:template match="/">
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="nl" lang="nl">
      <head>
        <title>Title</title>
        <link rel="stylesheet" href="/styles/shared/smoothness/jquery-ui-1.8.15.custom.css"/>
        <link rel="stylesheet" href="/styles/admin/default.less"/>
        <script language="javascript" src="/scripts/shared/jquery-1.6.2.min.js">
          <xsl:value-of select="''" />
        </script>
        <script language="javascript" src="/scripts/shared/jquery-ui-1.8.15.custom.min.js">
          <xsl:value-of select="''" />
        </script>
        <script language="javascript" src="/scripts/shared/autoresize.jquery.min.js">
          <xsl:value-of select="''" />
        </script>
        <script language="javascript" src="/scripts/admin/default.coffee">
          <xsl:value-of select="''" />
        </script>
      </head>
      <body>
        <xsl:apply-templates select="/" mode="content" />
        <textarea cols="30" rows="5">
          <xsl:copy-of select="/" />
        </textarea>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="/" mode="content">
    <p>No content template found.</p>
  </xsl:template>
</xsl:stylesheet>
