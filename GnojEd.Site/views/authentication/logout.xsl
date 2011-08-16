<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml" version="1.0">
  <xsl:import href="../admin/include/layout.xsl"/>

  <xsl:template match="/" mode="content">
    <h1>Logout</h1>
    <!-- Logged in -->
    <p>You're logged out.</p>
    <p><a href="/authentication/login">Do you want to login again?</a></p>
  </xsl:template>

</xsl:stylesheet>
