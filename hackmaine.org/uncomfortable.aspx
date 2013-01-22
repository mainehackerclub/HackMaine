<%@ Page Language="C#" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">

//   PROJECT HONEY POT ADDRESS DISTRIBUTION SCRIPT
//   For more information visit: http://www.projecthoneypot.org/
//   Copyright (C) 2004-2013, Unspam Technologies, Inc.
//   
//   This program is free software; you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation; either version 2 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//   
//   You should have received a copy of the GNU General Public License
//   along with this program; if not, write to the Free Software
//   Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA
//   02111-1307  USA
//   
//   If you choose to modify or redistribute the software, you must
//   completely disconnect it from the Project Honey Pot Service, as
//   specified under the Terms of Service Use. These terms are available
//   here:
//   
//   http://www.projecthoneypot.org/terms_of_service_use.php
//   
//   The required modification to disconnect the software from the
//   Project Honey Pot Service is explained in the comments below. To find the
//   instructions, search for:  *** DISCONNECT INSTRUCTIONS ***
//   
//   Generated On: Tue, 22 Jan 2013 08:08:46 -0800
//   For Domain: www.hackmaine.org
//   
//   

//   *** DISCONNECT INSTRUCTIONS ***
//   
//   You are free to modify or redistribute this software. However, if
//   you do so you must disconnect it from the Project Honey Pot Service.
//   To do this, you must delete the lines of code below located between the
//   *** START CUT HERE *** and *** FINISH CUT HERE *** comments. Under the
//   Terms of Service Use that you agreed to before downloading this software,
//   you may not recreate the deleted lines or modify this software to access
//   or otherwise connect to any Project Honey Pot server.
//   
//   *** START CUT HERE ***
//   
const string REQUEST_HOST       = "hpr1.projecthoneypot.org";
const string REQUEST_PORT       = "80";
const string REQUEST_SCRIPT     = "/cgi/serve.php";
//   
//   *** FINISH CUT HERE ***
//   

const string HPOT_TAG1          = "598be7db6cc70e67303322aad2182fb6";
const string HPOT_TAG2          = "5f5366245c08b9c260b4662338436c1b";
const string HPOT_TAG3          = "834b8bcc86d7919811fdae827091ac89";

const string CLASS_STYLE_1      = "rolachujite";
const string CLASS_STYLE_2      = "fromam";

const string DIV1               = "sw36o7u";

const string VANITY_L1          = "MEMBER OF PROJECT HONEY POT";
const string VANITY_L2          = "Spam Harvester Protection Network";
const string VANITY_L3          = "provided by Unspam";

const string DOC_TYPE1          = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">\n";
const string HEAD1              = "<html>\n<head>\n";
const string HEAD2              = "<title>Lovesickmotto</title>\n</head>\n";
const string ROBOT1             = "<meta name=\"robots\" content=\"noindex\">\n<meta name=\"robots\" content=\"noarchive,follow\">\n";
const string NOCOLLECT1         = "<meta name=\"no-email-collection\" content=\"/\">\n";
const string TOP1               = "<body>\n<center>\n";
const string EMAIL1A            = "<a href=\"mailto:";
const string EMAIL1B            = "\" style=\"display: none;\">";
const string EMAIL1C            = "</a>";
const string EMAIL2A            = "<a href=\"mailto:";
const string EMAIL2B            = "\" style=\"display:none;\">";
const string EMAIL2C            = "</a>";
const string EMAIL3A            = "<a style=\"display: none;\" href=\"mailto:";
const string EMAIL3B            = "\">";
const string EMAIL3C            = "</a>";
const string EMAIL4A            = "<a style=\"display:none;\" href=\"mailto:";
const string EMAIL4B            = "\">";
const string EMAIL4C            = "</a>";
const string EMAIL5A            = "<a href=\"mailto:";
const string EMAIL5B            = "\"></a>";
const string EMAIL5C            = "..";
const string EMAIL6A            = "<span style=\"display: none;\"><a href=\"mailto:";
const string EMAIL6B            = "\">";
const string EMAIL6C            = "</a></span>";
const string EMAIL7A            = "<span style=\"display:none;\"><a href=\"mailto:";
const string EMAIL7B            = "\">";
const string EMAIL7C            = "</a></span>";
const string EMAIL8A            = "<!-- <a href=\"mailto:";
const string EMAIL8B            = "\">";
const string EMAIL8C            = "</a> -->";
const string EMAIL9A            = "<div id=\""+DIV1+"\"><a href=\"mailto:";
const string EMAIL9B            = "\">";
const string EMAIL9C            = "</a></div><br><script language=\"JavaScript\" type=\"text/javascript\">document.getElementById('"+DIV1+"').innerHTML='';<"+"/script>";
const string EMAIL10A           = "<a href=\"mailto:";
const string EMAIL10B           = "\"><!-- ";
const string EMAIL10C           = " --></a>";
const string LEGAL1             = "";
const string LEGAL2             = "\n";
const string STYLE1             = "\n<style>a."+CLASS_STYLE_1+"{color:#FFF;font:bold 10px arial,sans-serif;text-decoration:none;}</style>";
const string VANITY1            = "<table cellspacing=\"0\"cellpadding=\"0\"border=\"0\"style=\"background:#999;width:230px;\"><tr><td valign=\"top\"style=\"padding: 1px 2px 5px 4px;border-right:solid 1px #CCC;\"><span style=\"font:bold 30px arial,sans-serif;color:#666;top:0px;position:relative;\">@</span></td><td valign=\"top\" align=\"left\" style=\"padding:3px 0 0 4px;\"><a href=\"http://www.projecthoneypot.org/\" class=\""+CLASS_STYLE_1+"\">"+VANITY_L1+"</a><br><a href=\"http://www.unspam.com\"class=\""+CLASS_STYLE_1+"\">"+VANITY_L2+"<br>"+VANITY_L3+"</a></td></tr></table>\n";
const string BOTTOM1            = "</center>\n</body>\n</html>\n";


string getLegalContent() { return "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">\n<tr>\n<td style=\"font-family: monospace;\">&#160; &#160; <br>&nbsp;<br>The <br>to y<br>&#111;the<br>W&#101;bs<br>read<br>age&#110;<br>them<br>non-<br>Webs<br><br>&#160; &#160; <br>&nbsp;<br>Spe&#99;<br>Non-<br>spid<br>&#112;rog<br>auto<br><br>&#69;mai<br>It i<br>al<!-- lobby evaluation orthodox dairy -->on<br>has<!-- aware --><font color=white>f</font><br>s&#116;or<br>valu<br>stor<br>agre<br><br>&#160; &#160; <br><font color=white>i</font><br>Each<br>agai<br>&#40;\"J&#117;<br>the <br>such<br>and <br>&#111;&#102; &#102;<br>&#97;ny <br>&#83;erv<br>the <br><br>&#160; <b><font color=white>c</font></b>&nbsp;<br>&nbsp;<br>Yo&#117; <br>&#109;ay <br>abus<br>&#86;i&#115;&#105;<br><br>&#86;ISI<br>PAR&#84;<br>SU&#66;S<br></td>\n<td style=\"font-family: monospace;\">&#160; &#160; <br><br>w&#101;bs<br>ou s<!-- reporting fullblooded pigeons chiffon --><br>r<font color=white>f</font>te<br>ite <br>&nbsp;the<br>t<!-- pure mark council -->s &#111;<br>. Th<br>tran<br>&#105;te.<br><br>&#160; &#160; <br><br>ial <br>Huma<br>er&#115;&#44;<br>rams<br>&#109;at&#105;<br><br>l ad<br>s re<br>&#101;.<font color=white>e</font>Y<br>a va<br>age,<br>e<font color=white>s</font>&#111;f<br>&#105;n&#103; <br>emen<br><br>&#160;&#160; <b><font color=white>d</font></b><br><br>&nbsp;&#112;ar<br>nst <br>di<!-- p severe monobasic -->ci<br>regi<br>&nbsp;la&#119;<br>pe&#114;&#102;<br>eder<br>acti<br>ice.<br>abov<br><br><b><font color=white>o</font></b>&#160;&#160; <br><br>c&#111;ns<br>&#97;pp&#101;<br>e. T<br>tors<br><br>&#84;ORS<br>Y OR<br>EQUE<br></td>\n<td style=\"font-family: monospace;\">&#160; &#160; <br><br>ite <br>u<!-- coastal unbecoming road -->bje<br>rms <br>y&#111;u <br>m c&#97;<br>&#102; th<br>e ac<br>sfer<br><br><br>&nbsp;<b><font color=white>g</font></b>&nbsp;<b><font color=white>d</font></b><br><br>re&#115;t<br>n Vi<br>&nbsp;bo<!-- distressed mural -->t<br>&nbsp;des<br>ca<!-- aftermost binomial british encouragement -->l&#108;<br><br>dre<!-- industrious fertility -->&#115;<br>&#99;&#111;gn<br>ou &#97;<br>lue <br>&nbsp;and<br>&nbsp;th&#101;<br>t&#104;is<br>t a&#110;<br><br>&#160; &#160; <br><br>ty<font color=white>i</font>a<br>t&#104;e <br>al<font color=white>a</font>&#65;<br>ster<br>s ar<br>or&#109;e<br>al a<br>on b<br>&nbsp;You<br>e ag<br><br>&#160; &#160; <br><br>ent<font color=white>o</font><br>ar s<br>&#104;e I<br>&nbsp;agr<br><br>&nbsp;AGR<br>&nbsp;&#83;EN<br>NT B<br></td>\n<td style=\"font-family: monospace;\">&#160; &#160; <br><br>&#102;rom<br>ct t<br>go&#118;e<br>acce<br>refu<br>e in<br>ces&#115;<br>&#97;ble<br><br><br>&#160;&#160; <b>S</b><br><br>rict<br>&#115;&#105;to<br>&#115;, i<br>i&#103;ne<!-- restrictive --><br>y.<br><br>ses <br>i<!-- syndrome -->zed<br>ck&#110;o<br>n&#111;t<font color=white>s</font><br>/or <br>se a<br>&nbsp;Web<br>d &#101;x<br><br><b><font color=white>f</font></b>&#160;&#160; <br><br>g<!-- appropriate explosion uncertain sand hypocrite -->ree<br>&#111;the<br>&#99;tio<br>&#101;&#100; A<br>e ap<br>d en<br>n&#100; s<br>&#114;oug<br>&nbsp;con<br>reem<br><br>&#160; <b><font color=white>c</font></b>&nbsp;<br><br>to &#104;<br>ome&#119;<br>dent<br>e&#101; n<br><br>EE T<br>DING<br>REAC<br></td>\n<td style=\"font-family: monospace;\">&#160; &#160; <br><br>&nbsp;&#119;hi<br>o th<br>rnin<br>&#112;t t<br>lly.<br>di&#118;i<br>&nbsp;rig<br>&nbsp;wit<br><br><br><b>PECI</b><br><br>ions<br>rs.<!-- pocket -->&nbsp;<br>ndex<br>d &#116;o<br><br><br>on t<br>&nbsp;tha<br>wle&#100;<br>&#108;es&#115;<br>&#100;&#105;st<br>ddre<br>s&#105;te<br>pres<br><br>&#160; <b><font color=white>o</font></b>&nbsp;<br><br>&#115; th<br>r<!-- impediments gear massive gang -->&nbsp;in<br>n\") <br>&#100;min<br>plie<br>t&#105;re<br>&#116;a&#116;e<br>ht a<br>&#115;ent<br>ent.<br><br>&#160; &#160; <br><br>avin<br>here<br>if&#105;e<br>ot t<br><br>HAT <br><font color=white>c</font>&#65;NY<br>H O&#70;<br></td>\n<td style=\"font-family: monospace;\"><b><font color=white>a</font></b>&#160;&#160; <br><br>ch y<br>e<font color=white>k</font>fo<br>g ac<br>hese<br>&nbsp;Any<br>&#100;u&#97;l<br>hts <br>hout<br><br><br><b>AL</b>&nbsp;<b>&#76;</b><br><br>&nbsp;on<font color=white>a</font><br>N&#111;n&#45;<br>ers,<br>&nbsp;acc<br><br><br>&#104;i&#115; <br>t t&#104;<br>ge a<br>&nbsp;tha<br>rib&#117;<br>&#115;&#115;es<!-- systematic choir girl perfoliate --><br>'s e<br>&#115;ly <br><br>&nbsp;<b><font color=white>s</font></b>&#160; <br><br>at a<br>&nbsp;con<br>sh&#97;l<br>is&#116;r<br>d to<br>l&#121; w<br>&nbsp;cou<br>gain<br>&nbsp;to <br><br><br>&nbsp;<b><font color=white>t</font></b>&#160; <br><br>g<font color=white>i</font>yo<br>&nbsp;on <br>r<!-- vacation rope debonair -->&nbsp;is<br>o us<br><br>HARV<br>&nbsp;MES<br><font color=white>p</font>THE<br></td>\n<td style=\"font-family: monospace;\">&#160;&#160; <b>T</b><br><br>ou &#97;<br>llow<br>&#99;ess<br>&nbsp;t&#101;r<br>&nbsp;Non<br>(s) <br>gran<br>&nbsp;the<br><br><br><b>ICE&#78;</b><br><br>a vi<br>Hum&#97;<br>&nbsp;&#114;ob<br>ess&#44;<br><br><br>si&#116;e<br>es&#101; <br>nd a<br>n U&#83;<br>tion<br>. In<br>mail<br>proh<br><br>&nbsp;<b>&#65;PP</b><br><br>n&#121; &#115;<br>n&#101;&#99;&#116;<br>l b<!-- pedigreed strong -->e<br>ativ<br>&nbsp;agr<br>ithi<br>rts <br>st<font color=white>f</font>&#104;<br>&#101;le&#99;<br><br><br><b>RECO</b><br><br>ur I<br>this<br>&nbsp;uni<br>e &#116;h<br><br>ESTI<br>SAGE<br>SE T<br></td>\n<td style=\"font-family: monospace;\"><b>ERMS</b><br><br>cces<br>ing <br>&nbsp;to <br>&#109;s a<br>-Hum<br>who <br>ted <br>&nbsp;exp<br><br><br><b>SE</b>&nbsp;<b>R</b><br><br>sito<br>n Vi<br>ots&#44;<br>&nbsp;re&#97;<br><br><br><font color=white>o</font>a&#114;e<br>emai<br>gr&#101;e<br>&nbsp;$5&#48;<br>&nbsp;o&#102; <br>tent<br><font color=white>f</font>add<br>ibit<br><br><b>LIC&#65;</b><br><br>uit,<br>ion <br>&nbsp;gov<br>e Co<br>ee&#109;e<br>n &#116;h<br>w&#105;th<br>im i<br>tron<br><br><br><b>RDS</b>&nbsp;<br><br>nter<br>&nbsp;pag<br>quel<br>is a<br><br>NG, <br>(S&#41; <br>ER<!-- cashandcarry preferred economy flashy futile -->MS<br></td>\n<td style=\"font-family: monospace;\">&nbsp;<b>&#65;ND</b><br><br>s&#101;d <br>co&#110;d<br>the <br>nd<font color=white>o</font>c<br>an V<br>c&#111;nt<br>to y<br>&#114;&#101;&#115;s<br><br><br><b>E&#83;TR</b><br><br>r'&#115; <br>si<!-- ethereal technological swine truant similarity -->to<br><font color=white>f</font>cra<br>d&#44; c<br><br><br><font color=white>g</font>c&#111;n<br>&#108; ad<br>&nbsp;th<!-- buzzards moaning willingness folks cabinet -->a<br>. Yo<br>the&#115;<br>io&#110;a<br>ress<br>ed.<br><br><b>BLE</b>&nbsp;<br><br><font color=white>c</font>ac&#116;<br>with<br>&#101;rne<br>nt&#97;c<br>nts <br>e &#65;&#100;<br>in t<br>n &#99;o<br>i&#99; s<br><br><br><b>O&#70;</b>&nbsp;<b>V</b><br><br>&#110;et <br>e<!-- accentual sulky brick code -->&nbsp;(t<br>y ma<br>ddre<br><br>GATH<br>TO &#84;<br>&nbsp;&#79;F <br></td>\n<td style=\"font-family: monospace;\">&nbsp;<b>CON</b><br><br>th&#105;&#115;<br>it&#105;o<br>Webs<br>o&#110;&#100;i<br>isit<br>r&#111;ls<br>ou u<br>&nbsp;wri<br><br><br><b>IC&#84;I</b><br><br>&#108;ice<br>rs i<br>wler<br>ompi<br><br><br>side<br>&#100;&#114;e&#115;<br>t ea<br>u fu<br>e ad<br>l &#99;o<br>es i<br><br><br><b>LAW</b>&nbsp;<br><br>i&#111;n <br>&nbsp;or <br>d<font color=white>g</font>by<br>t &#40;t<br>bet&#119;<br>min <br>he A<br>nnec<br>&#101;rvi<br><br><br><b>ISIT</b><br><br>Pro&#116;<br>he \"<br>tche<br>s&#115; f<br><br>ERIN<br>HE I<br>SERV<br></td>\n<td style=\"font-family: monospace;\"><b>DITI</b><br><br>&nbsp;agr<br>n&#115;. <br>i&#116;e&#46;<br>&#116;ion<br>ors <br>, a&#117;<br>nder<br>&#116;te&#110;<br><br><br><b>ONS</b>&nbsp;<br><br>nse <br>n&#99;lu<br>s&#44; &#104;<br>le<font color=white>o</font>o<br><br><br>&#114;ed<font color=white>t</font><br>&#115;es <br>ch e<br>rthe<br>dres<br>llec<br>s &#114;e<br><br><br><b>AND</b>&nbsp;<br><br>&#111;r p<br>ari&#115;<br>&nbsp;th&#101;<br>he \"<br>een<font color=white>h</font><br>Stat<br>dmin<br>t&#105;on<br>ce<font color=white>f</font>o<br><br><br><b>OR</b>&nbsp;<b>U</b><br><br>oco&#108;<br>I<!-- bodied verbal right imperial pregnant -->de&#110;<br>d t&#111;<br>or a<br><br>G&#44; &#83;<br>D&#69;NT<br>IC&#69;.<!-- isle touching --><br></td>\n<td style=\"font-family: monospace;\"><b>O&#78;&#83;</b>&nbsp;<br><br>eeme<br>T&#104;e<!-- dipteran walruses -->&#115;<br><font color=white>i</font>By <br>s (t<br>to t<br>thor<br>&nbsp;the<br>&nbsp;pe&#114;<br><br><br><b>F&#79;R</b>&nbsp;<br><br>to a<br>de, <br>arve<br>r ga<br><br><br>prop<br>ar&#101; <br>&#109;ail<br>r ag<br>ses <br>ti<!-- twin wooden stance asset edge -->on<br>cogn<br><br><br><b>JURI</b><br><br>roce<br>ing <br>&nbsp;law<br>A&#100;mi<br>&#65;d&#109;i<br>&#101;&#46; &#89;<br>&nbsp;Sta<br>&nbsp;wit<br>f p<!-- vocation bishop sepulchral -->&#114;<br><br><br><b>SE</b>&nbsp;<b>A</b><br><br>&nbsp;ad&#100;<br>tifi<br>&nbsp;you<br>ny r<!-- shoestring reptile horrible --><br><br>TO&#82;I<br>IFIE<br><br></td>\n<td style=\"font-family: monospace;\"><b>O<!-- formidable referral institution cage nervous -->F<font color=white>g</font>&#85;</b><br><br>nt (<br>e t&#101;<br>visi<br>&#104;e \"<br>he W<br>s or<br><font color=white>d</font>Ter<br>miss<br><br><br><b>NON-</b><br><br>cces<br>but <br>ster<br>th&#101;r<br><br><br>riet<br>pr&#111;&#118;<br>&nbsp;a&#100;d<br>re&#101; <br>subs<br>, ha<br>ized<br><br><br><b>&#83;DI&#67;</b><br><br>&#101;din<br>from<br>&nbsp;of<font color=white>o</font><br>n St<br>n St<br>ou c<br>te. <br>h b&#114;<br>oc&#101;s<br><br><br><b>ND</b>&nbsp;<b>A</b><br><br>res&#115;<br>er\")<br>r In<br>easo<br><br>N&#71;, <br>R CO<br><br></td>\n<td style=\"font-family: monospace;\"><b>SE</b>&nbsp;<br><br>\"the<br>&#114;ms <br>ting<br>&#84;erm<br>&#101;bsi<br>&nbsp;oth<br>&#109;s o<br>i&#111;n <br><br><br><b>HUMA</b><br><br>s th<br>a&#114;e <br>s&#44; o<br>&nbsp;co&#110;<br><br><br>ary <br>ided<br>ress<br>that<br>&#116;ant<br>&#114;ves<br>&nbsp;as <br><br><br><b>T<!-- midges purple submission pinnate -->&#73;ON</b><br><br>g br<br>&nbsp;the<br>the <br>ate\"<br>a&#116;e <br>ons<!-- religion specimen -->e<br>Yo<!-- japanese natives -->u <br>each<br>s re<br><br><br><b>BUS&#69;</b><br><br><font color=white>h</font>rec<br>&nbsp;if <br>t&#101;rn<br>n.<br><br>TRAN<br>N&#83;T<!-- commemorative family database legitimate -->I<br><br></td>\n<td style=\"font-family: monospace;\"><br><br>&nbsp;We&#98;<br>a&#114;e <br><font color=white>k</font>(in<br>s &#111;f<br>t&#101; s<br>erwi<br>f Se<br>of t<br><br><br><b>N</b>&nbsp;<b>&#86;I</b><br><br>e We<br>n&#111;t <br>r &#97;n<br>t&#101;nt<br><br><br>inte<br>&nbsp;for<br>&nbsp;the<br>&nbsp;the<br>iall<br>ting<br>a vi<br><br><br>&nbsp;<br><br>ough<br><font color=white>f</font>Ter<br>st&#97;t<br>) &#102;o<br>resi<br>nt &#116;<br>cons<br>es o<br>gar&#100;<br><br><br>&nbsp;<br><br>or&#100;e<br>w<!-- upward lewd exogenous babe -->e s<br>et P<br><br><br>SFE&#82;<br>&#84;UTE<br><br></td>\n<td style=\"font-family: monospace;\"><br><br>site<br>in a<br>&nbsp;any<br><font color=white>g</font>Ser<br>hal&#108;<br>s&#101; m<br>rvic<br>he o<br><br><br><b>SITO</b><br><br>bs<!-- fahrenheit -->it<br>l<!-- tubular didactic oleaginous shopper -->&#105;mi<br>y o<!-- government diameter abdomen -->t<br>&nbsp;fro<br><br><br>&#108;lec<br>&nbsp;h&#117;m<br>&nbsp;We&#98;<br>&nbsp;com<br>&#121; di<!-- resounding routine jar machinery inn --><br>, &#103;a<br>olat<br><br><br><br><br>t &#98;y<br>ms o<br>e of<br>r t&#104;<br>dent<br>o<font color=white>t</font>th<br>e&#110;&#116; <br>f th<br>ing <br><br><br><br><br>d.<font color=white>s</font>A<br>&#117;s&#112;e<br>ro&#116;o<br><br><br>&#82;ING<br>S AN<br><br></td>\n<td style=\"font-family: monospace;\"><br><br>\") i<br>&#100;d&#105;t<br>&nbsp;man<br>vic<!-- white sailor league punch property -->e<br>&nbsp;be <br>akes<br>e ar<br>wner<br><br><br><b>&#82;S</b>&nbsp;<br><br>e ap<br>t&#101;d <br>her <br>m &#116;h<br><br><br>tual<br>a&#110; v<br>s&#105;te<br>pila<br>mini<br>ther<br>io&#110; <br><br><br><br><br>&nbsp;s&#117;c<br>f<font color=white>g</font>Se<br>&nbsp;res<br>e We<br>s en<br>e ju<br>t&#111; &#116;<br>es<!-- commodity registered prosperity inaugural -->e<font color=white>t</font><br>acti<br><br><br><br><br>n em<br>ct &#112;<br>&#99;ol <br><br><br>&nbsp;TO <br><font color=white>p</font>&#65;CC<br><br></td>\n<td style=\"font-family: monospace;\"><br><br>s pr<br>io&#110; <br>ner&#41;<br>\"&#41;. <br>c&#111;ns<br>&nbsp;use<br>e<br>&nbsp;of <br><br><br><br><br>ply<font color=white>f</font><br>to, <br>comp<br>&#101; We<br><br><br>&nbsp;pro<br>is&#105;t<br>&nbsp;con<br>t&#105;on<br>&#115;hes<br>ing,<br>of t<br><br><br><br><br>&#104; pa<br>&#114;v&#105;c<br>iden<br>bsit<br>tere<br>ri&#115;d<br>he v<br>Term<br>ons <br><br><br><br><br>ail <br>&#111;ten<br>addr<br><br><br>A TH<br>&#69;PTA<br><br></td>\n<td style=\"font-family: monospace;\"><br><br>o&#118;id<br>to a<br>&nbsp;the<br>Plea<br>i&#100;&#101;r<br><font color=white>e</font>of<br><br>th&#101;<br><br><br><br><br>to<br>web<br>uter<br>bs&#105;t<br><br><br>per<!-- correct corky corporation vulpine rising -->t<br>or&#115;<br>tain<br>,<br>&nbsp;the<br>&nbsp;and<br>his<br><br><br><br><br>rty<br>e<br>ce o<br>e as<br>d<font color=white>f</font>in<br>ict&#105;<br>e&#110;ue<br>&#115; of<br>unde<br><br><br><br><br>a&#100;dr<br>tial<br>ess&#46;<br><br><br>IRD<br>NCE<font color=white>p</font><br><br></td>\n<td style=\"font-family: monospace;\"><br><br>e&#100;<br>ny<br><br>se<br>ed<br><br><br><br><br><br><br><br><br><br><br>e<br><br><br>y.<br><br>s<br><br><br>/or<br><br><br><br><br><br><br><br>f<br><br>&#116;o<br>on<br><font color=white>d</font>&#105;n<br><br>r<br><br><br><br><br>es&#115;<br><br><br><br><br><br>AND<br><br></td>\n</tr>\n</table>\n<br>"; }




	protected string GetEmailHTML(string Method, string Email)
	{
	  switch (Method)
	  {
		  case "0":
			  return "";
		  case "1":
			  return EMAIL1A + Email + EMAIL1B + Email + EMAIL1C;
		  case "2":
			  return EMAIL2A + Email + EMAIL2B + Email + EMAIL2C;
		  case "3":
			  return EMAIL3A + Email + EMAIL3B + Email + EMAIL3C;
		  case "4":
			  return EMAIL4A + Email + EMAIL4B + Email + EMAIL4C;
		  case "5":
			  return EMAIL5A + Email + EMAIL5B + Email + EMAIL5C;
		  case "6":
			  return EMAIL6A + Email + EMAIL6B + Email + EMAIL6C;
		  case "7":
			  return EMAIL7A + Email + EMAIL7B + Email + EMAIL7C;
		  case "8":
			  return EMAIL8A + Email + EMAIL8B + Email + EMAIL8C;
		  case "9":
			  return EMAIL9A + Email + EMAIL9B + Email + EMAIL9C;
		  default:
			  return EMAIL10A + Email + EMAIL10B + Email + EMAIL10C;
	  }
	}

	protected void WriteIfSet(string key)
	{
		  if (Settings.ContainsKey(key))
		  {
			  Response.Write(Settings[key + "Msg"]);
		  }
	}

	protected void WriteIfOn(string key)
	{
		  string val;
		  if (Settings.TryGetValue(key + "On", out val) && !String.IsNullOrEmpty(val))
		  {
			  if (Settings.ContainsKey(key))
			  {
				  Response.Write(Settings[key]);
			  }
			  else
			  {
				  Response.Write(Settings[key + "Msg"]);
			  }
		  }
	}

  private string PerformRequest(string p)
  {
	  HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + REQUEST_HOST + REQUEST_SCRIPT);
	  request.Method = "POST";
	  request.Headers.Add("Cache-Control", "no-cache");
	  request.UserAgent = "PHPot " + HPOT_TAG2;
	  request.ContentType = "application/x-www-form-urlencoded";
	  request.KeepAlive = false;

	  byte[] bytes = Encoding.UTF8.GetBytes(p);

	  request.ContentLength = bytes.Length;
	  using (Stream requestStream = request.GetRequestStream())
	  {
		  requestStream.Write(bytes, 0, bytes.Length);

		  try
		  {
			  using (WebResponse response = request.GetResponse())
			  {
				  using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				  {
					  return reader.ReadToEnd();
				  }
			  }
		  }
		  catch (WebException we)
		  {
			  StreamReader sr = new StreamReader(we.Response.GetResponseStream());
			  throw new Exception(sr.ReadToEnd(), we);
		  }
	  }
  }


	public Dictionary<string, string> PrepareRequest()
	{
		Dictionary<string, string> postvars = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		postvars.Add("tag1", HPOT_TAG1);
		postvars.Add("tag2", HPOT_TAG2);
		postvars.Add("tag3", HPOT_TAG3);

		string md5 = "00000000000000000000000000000000";
		try
		{
			if (!String.IsNullOrEmpty(ForcedScriptFile ?? AppRelativeVirtualPath))
			{
				string scriptPath = ForcedScriptFile ?? Server.MapPath(AppRelativeVirtualPath);
				MD5 md5er = MD5CryptoServiceProvider.Create();
				byte[] hash = md5er.ComputeHash(System.Text.Encoding.ASCII.GetBytes(_Cleaner.Replace(File.ReadAllText(scriptPath),"")));
				System.Text.StringBuilder hashBuilder = new StringBuilder(32);
				foreach (byte b in hash)
				{
					hashBuilder.Append(b.ToString("x2"));
				}
				md5 = hashBuilder.ToString();
			}
		}
		catch (Exception)
		{
		}
		postvars.Add("tag4", md5);
		postvars.Add("ip", HttpUtility.UrlEncode(Request.ServerVariables["REMOTE_ADDR"]));
		postvars.Add("svrn", HttpUtility.UrlEncode(Request.ServerVariables["SERVER_NAME"]));
		postvars.Add("svp", HttpUtility.UrlEncode(Request.ServerVariables["SERVER_PORT"]));
        postvars.Add("svip", HttpUtility.UrlEncode(ForcedIP ?? Request.ServerVariables["SERVER_ADDR"]));
		postvars.Add("rquri", HttpUtility.UrlEncode(ForcedScriptUri ?? Request.ServerVariables["URL"]));
		postvars.Add("sn", HttpUtility.UrlEncode(ForcedScriptName ?? Request.ServerVariables["SCRIPT_NAME"]).Replace(" ", "%20"));
		postvars.Add("ref", HttpUtility.UrlEncode(Request.ServerVariables["HTTP_REFERER"]));
		postvars.Add("uagnt", HttpUtility.UrlEncode(Request.ServerVariables["HTTP_USER_AGENT"]));

        if (Request.HttpMethod == "POST" && Request.Form.Count > 0)
        {

              postvars.Add("has_post", ""+Request.Form.Count);

              foreach (string key in Request.Form.Keys)
              {
                    postvars["post|" + key] = Request.Form[key];
              }

        }

        if (Request.QueryString.Count > 0)
        {

              postvars.Add("has_get", ""+Request.QueryString.Count);

              foreach (string key in Request.QueryString.Keys)
              {
                    postvars["get|" + key] = Request.QueryString[key];
              }      

        }
		return postvars;
	}

  private Dictionary<string, string> TranscribeResponse(string response)
  {
	  Dictionary<string, string> settings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
	  //string[] arr = HttpUtility.UrlDecode(response).Split((char)10);
      string[] arr = response.Split((char)10);
	  bool isParam = false;

	  for (int j = 0; j < arr.Length; j++)
	  {
		  if (arr[j] == "<END>")
		  {
			  isParam = false;
		  }

		  if (isParam)
		  {
			  string[] pieces = arr[j].Split(_splitChars, 2);
			  if (pieces.Length == 2)
			  {
				  settings.Add(pieces[0], HttpUtility.UrlDecode(pieces[1]));
			  }
		  }

		  if (arr[j] == "<BEGIN>")
		  {
			  isParam = true;
		  }
	  }
	  return settings;
  }

  protected string Directive(int index)
  {
	  if (Directives != null && Directives.Length > index)
	  {
		  return Directives[index];
	  }
	  return null;
  }

  protected override void Render(HtmlTextWriter writer)
  {
	  Dictionary<string, string> post = PrepareRequest();

	  StringBuilder RequestText = new StringBuilder();
	  foreach (KeyValuePair<string, string> kv in post)
	  {
		  if (RequestText.Length > 0)
		  {
			  RequestText.Append('&');
		  }
		  RequestText.Append(kv.Key).Append('=').Append(kv.Value);
	  }
	  string ResponseText = PerformRequest(RequestText.ToString());
	  Settings = TranscribeResponse(ResponseText);
	  if (Settings.ContainsKey("directives"))
	  {
		  Directives = Settings["directives"].Split(',');
	  }
      Response.Cache.SetCacheability(HttpCacheability.NoCache);
	  Response.Cache.AppendCacheExtension("no-store");
	  base.Render(writer);
  }

  static Regex _Cleaner = new Regex("[^0-9a-zA-Z]");
  static char[] _splitChars = new char[] { '=' };
  static string ForcedScriptFile = ConfigurationManager.AppSettings["ProjectHoneyPot.ScriptSource"];
  static string ForcedScriptName = ConfigurationManager.AppSettings["ProjectHoneyPot.ScriptName"];
  static string ForcedScriptUri = ConfigurationManager.AppSettings["ProjectHoneyPot.ScriptUri"];
  static string ForcedIP = ConfigurationManager.AppSettings["ProjectHoneyPot.MyIP"];
  string[] Directives;
  Dictionary<string, string> Settings;
  
  void WritePageContent()
  {
	  if (Directive(0) == "1") Response.Write(DOC_TYPE1);
	  WriteIfSet("injDocType");
	  if (Directive(1) == "1") Response.Write(HEAD1);
	  WriteIfSet("injHead1HTML");
	  if (Directive(8) == "1") Response.Write(ROBOT1);
	  WriteIfSet("injRobotHTML");
	  if (Directive(9) == "1") Response.Write(NOCOLLECT1);
	  WriteIfSet("injNoCollectHTML");
	  if (Directive(1) == "1") Response.Write(HEAD2);
	  WriteIfSet("injHead2HTML");
	  if (Directive(2) == "1") Response.Write(TOP1);
	  WriteIfSet("injTopHTML");
	  WriteIfOn("actMsg");
	  WriteIfOn("errMsg");
	  WriteIfOn("customMsg");
	  if (Directive(3) == "1") Response.Write(LEGAL1 + getLegalContent() + LEGAL2);
	  WriteIfSet("injLegalHTML");
	  WriteIfOn("altLegal");
	  if (Directive(4) == "1") Response.Write(GetEmailHTML(Settings["emailmethod"], Settings["email"]));
	  WriteIfSet("injEmailHTML");
	  if (Directive(5) == "1") Response.Write(STYLE1);
	  WriteIfSet("injStyleHTML");
	  if (Directive(6) == "1") Response.Write(VANITY1);
	  WriteIfSet("injVanityHTML");
	  WriteIfOn("altVanity");
	  if (Directive(7) == "1") Response.Write(BOTTOM1);
	  WriteIfSet("injBottomHTML");
  }
</script>
<% WritePageContent(); %>
