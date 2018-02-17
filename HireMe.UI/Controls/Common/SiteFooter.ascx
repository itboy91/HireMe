<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteFooter.ascx.cs" Inherits="HireMe.UI.Controls.Common.SiteFooter" %>
 
<style>
    .footer-bs {
    background-color: white;
	padding: 60px 40px;
	color: blue;
	margin-bottom: 20px;
	border-bottom-right-radius: 6px;
	border-top-left-radius: 0px;
	border-bottom-left-radius: 6px;
}
.footer-bs .footer-brand, .footer-bs .footer-nav, .footer-bs .footer-social, .footer-bs .footer-ns { padding:10px 25px; }
.footer-bs .footer-nav, .footer-bs .footer-social, .footer-bs .footer-ns { border-color: transparent; }
.footer-bs .footer-brand h2 { margin:0px 0px 10px; }
.footer-bs .footer-brand p { font-size:12px; color:blue; }

.footer-bs .footer-nav ul.pages { list-style:none; padding:0px; }
.footer-bs .footer-nav ul.pages li { padding:5px 0px;}
.footer-bs .footer-nav ul.pages a { color:blue; font-weight:bold; text-transform:uppercase; }
.footer-bs .footer-nav ul.pages a:hover { color:blue; text-decoration:underline; }
.footer-bs .footer-nav h4 {
	font-size: 11px;
	text-transform: uppercase;
	letter-spacing: 3px;
	margin-bottom:10px;
}
.fa-chevron-circle-up {
  background: yellow;
  border-radius: 50%;
  height: 1em;
  width: 1em;
}
.footer-bs .footer-nav ul.list { list-style:none; padding:0px;  }
.footer-bs .footer-nav ul.list li { padding:5px 0px;}
.footer-bs .footer-nav ul.list a { color:blue; }
.footer-bs .footer-nav ul.list a:hover { color:blue; text-decoration:underline; }

.footer-bs .footer-social ul { list-style:none; padding:0px; }
.footer-bs .footer-social h4 {
	font-size: 11px;
	text-transform: uppercase;
	letter-spacing: 3px;
}
.footer-bs .footer-social li { padding:5px 4px;}
.footer-bs .footer-social a { color:blue;}
.footer-bs .footer-social a:hover { color:blue; text-decoration:underline; }

.footer-bs .footer-ns h4 {
	font-size: 11px;
	text-transform: uppercase;
	letter-spacing: 3px;
	margin-bottom:10px;
}
.footer-bs .footer-ns p { font-size:12px; color:blue; }

@media (min-width: 768px) {
	.footer-bs .footer-nav, .footer-bs .footer-social, .footer-bs .footer-ns { border-left:solid 1px rgb(211,211,211); }
}
/*.footer2 {
  background: #061D25;
  padding: 10px 0;
}*/
.footer2 a {
  color: #70726F;
  font-size: 20px;
  padding: 10px;
  border-right: 1px solid #70726F;
  transition: all .5s ease;
    background: #061D25;
}
.footer2 a:first-child {
  border-left: 1px solid #70726F;
}
.footer2 a:hover {
  color: white;
}
</style>

<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css" rel="stylesheet"/>

<footer class="footer-bs">
        <div class="row">
        	<div class="col-md-3 footer-brand animated fadeInLeft">
            	<h2></h2>
                <p></p>
                <p>HireMe89&reg <%: DateTime.Now.Year %> </p>
            
            </div>
        	<div class="col-md-4 footer-nav animated fadeInUp">
            	<h4>Menu —</h4>
            	
            	<div class="col-md-6">
                    <ul class="list">
                        <li><a href="#">About Us</a></li>
                        <li><a href="#">Contacts</a></li>
                        <li><a href="#">Terms & Condition</a></li>
                        <li><a href="#">Privacy Policy</a></li>
                    </ul>
                </div>
            </div>
        	<div class="col-md-2 footer-social animated fadeInDown">
                <div class=" text-center">
            	<h4>Follow Us</h4>
            	<ul>
                	<li><a href="https://www.facebook.com/Hireme-89-1595352853841546/"><i class="fa fa-facebook footer2"></i></a></li>
                	<li><a href="https://twitter.com/?lang=en"><i class="fa fa-twitter footer2"></i></a></li>
                	<li><a href="https://www.instagram.com/hireme89/?hl=en"><i class="fa fa-instagram footer2"></i></a></li>
                </ul>
                    </div>
                </div>
<%--    <a href="#"></a>
    <a href="#"><i class="fa fa-twitter"></i></a>
    <a href="#"><i class="fa fa-linkedin"></i></a>
    <a href="#"><i class="fa fa-google-plus"></i></a>
    <a href="#"><i class="fa fa-skype"></i></a>--%>


        	<div class="col-md-3 ">
         
            </div>
     </div>
    </footer>