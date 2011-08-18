<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">

  <xsl:import href="include/layout.xsl"/>

  <xsl:variable name="siteNode" select="/data/Model/Site"/>

  <xsl:template match="/" mode="content">
    <form method="post">
      <xsl:attribute name="action">
        <xsl:choose>
          <xsl:when test="$siteNode/Id">
            <!-- Update -->
            <xsl:text>/admin/site/</xsl:text>
            <xsl:value-of select="$siteNode/Id" />
            <xsl:text>/update</xsl:text>
          </xsl:when>
          <xsl:otherwise>
            <!-- Create -->
            <xsl:text>/admin/site/create</xsl:text>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>

      <fieldset>
        <legend>Site</legend>
        <input type="hidden" name="Id" id="Id" value="{$siteNode/Id}" />

        <div class="row">
          <label for="Name" class="title">Name</label>
          <input class="ui-widget-content" type="text" name="Name" id="Name" value="{$siteNode/Name}" />
        </div>
        <div class="row">
          <label for="Aka" class="title">Aka</label>
          <input class="ui-widget-content" type="text" name="Aka" id="Aka" value="{$siteNode/Aka}" />
        </div>
        <div class="row">
          <label for="ViewId" class="title">ViewId</label>
          <input class="ui-widget-content" type="text" name="ViewId" id="ViewId" value="{$siteNode/ViewId}" />
        </div>
      </fieldset>

      <input class="ui-widget-content" type="submit" />
    </form>
  </xsl:template>
</xsl:stylesheet>
