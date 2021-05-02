<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="utf-8" indent="yes"/>

  <xsl:template match="/">
    <schemaExplorer xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <xsl:element name="schemaProviders">
        <xsl:for-each select="/configuration/schemaExplorer/schemaProviders/add">
          <xsl:element name="schemaProvider">
            <xsl:value-of select="@type"/>
          </xsl:element>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="dataSources">
        <xsl:for-each select="/configuration/schemaExplorer/dataSources/add">
          <xsl:element name="dataSource">
            <xsl:attribute name="name">
              <xsl:value-of select="@name"/>
            </xsl:attribute>
            <xsl:attribute name="connectionString">
              <xsl:value-of select="@connectionString"/>
            </xsl:attribute>
            <xsl:attribute name="providerType">
              <xsl:value-of select="@providerType"/>
            </xsl:attribute>
          </xsl:element>
        </xsl:for-each>
      </xsl:element>
      <xsl:apply-templates select="/configuration/schemaExplorer/dataSources/add[@selected='true']" />
    </schemaExplorer>
  </xsl:template>

  <xsl:template match="add">
    <xsl:element name="selectedDataSource">
      <xsl:attribute name="name">
        <xsl:value-of select="@name"/>
      </xsl:attribute>
      <xsl:attribute name="connectionString">
        <xsl:value-of select="@connectionString"/>
      </xsl:attribute>
      <xsl:attribute name="providerType">
        <xsl:value-of select="@providerType"/>
      </xsl:attribute>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>