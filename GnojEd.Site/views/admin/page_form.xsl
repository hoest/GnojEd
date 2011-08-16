<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">

  <xsl:import href="include/layout.xsl"/>

  <xsl:template match="/" mode="content">
    <form method="post" action="/admin/page/create">
      <fieldset>
        <legend>Meta</legend>
        <div class="row">
          <label for="creator" class="title">
            Creator
          </label>
          <input class="ui-widget-content" type="text" name="creator" id="creator" value="1" />
        </div>
        <div class="row">
          <label for="editor" class="title">
            Editor
          </label>
          <input class="ui-widget-content" type="text" name="editor" id="editor" value="1" />
        </div>
        <div class="row">
          <label for="title" class="title">
            Title
          </label>
          <input class="ui-widget-content" type="text" name="title" id="title" value="" />
        </div>
        <div class="row">
          <label for="aka" class="title">
            Alias
          </label>
          <input class="ui-widget-content" type="text" name="aka" id="aka" value="" />
        </div>
        <div class="row">
          <label for="description" class="title">
            Description
          </label>
          <textarea name="description" id="description" cols="30" rows="5">
            <xsl:value-of select="''" />
          </textarea>
        </div>
      </fieldset>

      <fieldset>
        <legend>Page</legend>
        <div class="row">
        <div class="row">
          <label for="site" class="title">
            Site
          </label>
          <input class="ui-widget-content" type="text" name="site" id="site" value="1" />
        </div>
          <label for="introduction" class="title">
            Introduction
          </label>
          <textarea name="introduction" id="introduction" cols="30" rows="5">
            <xsl:value-of select="''" />
          </textarea>
        </div>
        <div class="row">
          <label for="text" class="title">
            Text
          </label>
          <textarea name="text" id="text" cols="30" rows="5">
            <xsl:value-of select="''" />
          </textarea>
        </div>
      </fieldset>

      <input class="ui-widget-content" type="submit" />
    </form>
  </xsl:template>
</xsl:stylesheet>
