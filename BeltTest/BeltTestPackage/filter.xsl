<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" exclude-result-prefixes="xsl wix"
                xmlns:wix="http://wixtoolset.org/schemas/v4/wxs"
                xmlns="http://wixtoolset.org/schemas/v4/wxs">

  <xsl:output method="xml" indent="yes" omit-xml-declaration="yes" />

  <xsl:strip-space elements="*" />

  <xsl:key name="FilterExes" match="wix:Component[substring(wix:File/@Source, string-length(wix:File/@Source) - 3) = '.exe']" use="@Id" />
  <xsl:key name="FilterPdbs" match="wix:Component[substring(wix:File/@Source, string-length(wix:File/@Source) - 3) = '.pdb']" use="@Id" />
  <xsl:key name="FilterClassLibrary1" match="wix:Component[wix:File/@Source = 'SourceDir\ClassLibrary1.dll']" use="@Id" />

  <!-- Copy all elements and their attributes. -->
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()" />
    </xsl:copy>
  </xsl:template>

  <!-- Except for those that match our filters, do nothing. -->
  <xsl:template match="*[ self::wix:Component or self::wix:ComponentRef ][ key( 'FilterExes', @Id ) ]" />
  <xsl:template match="*[ self::wix:Component or self::wix:ComponentRef ][ key( 'FilterPdbs', @Id ) ]" />
  <xsl:template match="*[ self::wix:Component or self::wix:ComponentRef ][ key( 'FilterClassLibrary1', @Id ) ]" />
</xsl:stylesheet>
