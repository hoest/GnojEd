<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">
  <xsl:import href="../admin/include/layout.xsl"/>

  <xsl:param name="ref" select="'/admin'" />

  <xsl:template match="/" mode="content">
    <h1>Login</h1>
    <xsl:choose>
      <xsl:when test="data/Model/authenticated = 'true'">
        <!-- Logged in -->
        <p>You're already logged in.</p>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="$invalid = 'true'">
          <p>Username or password is incorrect.</p>
        </xsl:if>
        <form method="post" action="/authentication/login">
          <fieldset>
            <legend>Loginform</legend>
            <input type="hidden" name="referrer" value="{$ref}" />

            <div class="row">
              <label for="username" class="title">Username</label>
              <input class="ui-widget-content" type="text" name="username" id="username" />
            </div>
            <div class="row">
              <label for="password" class="title">Password</label>
              <input class="ui-widget-content" type="password" name="password" id="password" />
            </div>
            <div class="row">
              <input class="ui-widget-content" type="submit" />
            </div>
          </fieldset>
        </form>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

</xsl:stylesheet>
