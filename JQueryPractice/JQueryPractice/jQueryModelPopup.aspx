<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jQueryModelPopup.aspx.cs" Inherits="JQueryPractice.jQueryModelPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.8.0.js" type="text/javascript"></script>
    <title></title>
    <style type="text/css">
        /* Z-index of #mask must lower than #boxes .window */

   
        #boxes .window {
          position:fixed;
          width:250px;
          height:150px;
          display:none;
          z-index:9999;
          padding:20px;
          font-family: Calibri;
        } 
 
        /* Customize your modal window here, you can add background image too */
        #boxes #dialog {
          width:250px; 
          height:100px;
          border: 2px Solid Red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- #dialog is the id of a DIV defined in the code below -->
        <%--<a href="#dialog" name="modal">Simple Modal Window</a>--%>

        <input id="btnShow" value="Click here to see popup" type="button" />
        <br />
        <br />
        <input id="btnChangeContent" value="Click here to change content" type="button" />
 
        <div id="boxes">     
            <!-- #customize your modal window here --> 
            <div id="dialog" class="window">
                <span style="font-weight: bold; color: Green;">This is my popup header &nbsp;(<a href="#" class="close">Close</a>)</span><br />
                <div id="popContent">
                    <b>This is my content div for my popup</b>
                </div>
            </div>
        </div>

    <script type="text/javascript">

        $(document).ready(function () {

            var myModelPopupObj = $('#dialog');
            //select all the a tag with name equal to modal
            $('#btnShow').click(function (e) {
                myModelPopupObj.show();
            });

            //select all the a tag with name equal to modal
            $('#btnChangeContent').click(function (e) {
                $('#popContent').html("Like this you can add your content to popup");
            });

            //if close button is clicked
            $('.window .close').click(function (e) {
                //Cancel the link behavior
                e.preventDefault();
                myModelPopupObj.hide();
            });

        });
 
    </script>
    </form>
</body>
</html>
