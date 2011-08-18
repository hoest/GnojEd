<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">

  <xsl:import href="include/layout.xsl"/>

  <xsl:template match="/" mode="content">
    <table>
      <xsl:for-each select="data/Model/ArrayOfSite/Site">
        <tr>
          <td>
            <xsl:value-of select="Name" />
          </td>
          <td>
            <xsl:value-of select="Aka" />
          </td>
          <td>
            <a href="/admin/site/{Id}/update">Edit</a>
          </td>
          <td>
            <a href="#">Delete</a>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
