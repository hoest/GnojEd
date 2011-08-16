<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">
  <xsl:import href="../admin/include/layout.xsl"/>

  <xsl:template match="/" mode="content">
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
  </xsl:template>

</xsl:stylesheet>
