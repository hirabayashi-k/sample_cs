<?xml version="1.0" encoding="Shift_JIS"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" encoding="Shift_JIS"/> 

<xsl:template match="/ReverseDictionary">
<html>
<head>
<link rel="stylesheet" href="reversedic.css" />
<title>�t��������</title>
</head>
<body>

<h1>C# �t��������</h1>

<!-- �J�e�S���[�ꗗ -->
<xsl:for-each select="category">
<p class="list">
	<a>
	<xsl:attribute name="href">
	<xsl:text>#c-</xsl:text><xsl:number count="category" format="01" />
	</xsl:attribute>
	<span class="symbol">��</span>
	</a>
		<xsl:text> </xsl:text>
	<xsl:value-of select="@name" />
</p>
</xsl:for-each>

<!-- �J�e�S���[�\�� -->
<xsl:for-each select="category">
<h2><a>
	<xsl:attribute name="id">
	<xsl:text>c-</xsl:text><xsl:number count="category" format="01" />
	</xsl:attribute>
	<xsl:value-of select="@name" />
</a></h2>

	<!-- ���ڈꗗ -->
	<xsl:for-each select="item">
	<p class="itemlist">
		<a>
		<xsl:attribute name="href">
		<xsl:text>#i-</xsl:text>
		<xsl:number count="category" format="01" />
		<xsl:text>-</xsl:text>
		<xsl:number count="item" format="01" />
		</xsl:attribute>
		<span class="symbol">��</span>
		</a>
		<xsl:text> </xsl:text>
		<xsl:value-of select="@name" />
	</p>
	</xsl:for-each>

	<xsl:for-each select="item">
	<div class="item">
		<h2 class="q">
		<a>
			<xsl:attribute name="id">
			<xsl:text>i-</xsl:text>
			<xsl:number count="category" format="01" />
			<xsl:text>-</xsl:text>
			<xsl:number count="item" format="01" />
			</xsl:attribute>
			<xsl:value-of select="@name" />
		</a>
		</h2>
		<div class="a"><xsl:apply-templates select="." /></div>
	</div>
	</xsl:for-each>
</xsl:for-each>

</body>
</html>
</xsl:template>

<!-- HTML�^�O�����̂܂ܕ\���ł���悤�� -->
<xsl:template match="*|text()">
<xsl:copy>
<xsl:for-each select="@*">
<xsl:copy/>
</xsl:for-each>
<xsl:apply-templates/>
</xsl:copy>
</xsl:template>

</xsl:stylesheet>
