<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">
  <xsl:output method="xml" version="1.0" encoding="utf-8"
              doctype-public="-//W3C//DTD XHTML 1.0 Strict//EN"
              doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"
              indent="yes"/>

  <xsl:template match="/">
    <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="nl" lang="nl">
      <head>
        <title>Error occurred</title>
        <link rel="stylesheet" href="/styles/error/default.css"/>
      </head>
      <body>
        <h1>Error occurred</h1>
        <p>
          <xsl:value-of select="data/Model/Error/Message" />
        </p>
        <p>
          <strong>Url</strong>
          <xsl:text>: </xsl:text>
          <xsl:value-of select="data/Model/Error/Url" />
        </p>
        <p>
          <strong>StackTrace</strong>
          <xsl:text>: </xsl:text>
        </p>
        <pre>
          <xsl:value-of select="data/Model/Error/StackTrace" />
        </pre>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
