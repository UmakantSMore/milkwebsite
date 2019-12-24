<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="addeditfarmer.aspx.cs" Inherits="addeditfarmer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>

    <div class="row">
        <!-- left column -->
        <div class="col-md-12">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3><span style="color: red">* Indicates Required Fields</span></h3>
                    <h3 class="box-title" style="text-align: center"><b id="spnMessgae" runat="server"></b></h3>
                    <%--<cc1:ToolkitScriptManager ID="toolScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
                </div>
                <!-- /.box-header -->
                <!-- form start -->

                <div class="box-body">

                    <div class="form-group row">

                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">Name<span style="color: red">*</span> </label>
                            <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtname" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>

                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">Mobile No<span style="color: red">*</span> </label>
                            <asp:TextBox ID="txtmobileno" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtmobileno" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmobileno" ValidationGroup="gg" ValidationExpression="^\d+" ErrorMessage="*" Font-Bold="True" Font-Size="Large" />
                        </div>
                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">Password<span style="color: red">*</span> </label>
                            <asp:TextBox ID="txtpassword" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtpassword" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-xs-3" style="display:none">
                            <label for="exampleInputEmail1">Milk Rate<span style="color: red">*</span> </label>
                            <asp:TextBox ID="txtmilkrate" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtmilkrate" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmilkrate" ValidationGroup="gg" ValidationExpression="^-?([0-9]{0,9}(\.[0-9]{0,2})?|100(\.00?)?)$" ErrorMessage="*" Font-Bold="True" Font-Size="Large" />

                        </div>
                    </div>
                    
                    
                    
                    <div class="form-group row">

                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">Email<span style="color: red">*</span> </label>
                            <asp:TextBox ID="txtemailid" CssClass="form-control" runat="server"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtname" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemailid" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                        </div>
                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">Bank <span style="color: red">*</span></label>
                            <asp:TextBox ID="txtbank" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtbank" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">Account No <span style="color: red">*</span></label>
                            <asp:TextBox ID="txtaccountno" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtaccountno" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                    
                    <div class="form-group row">

                        
                        <div class="col-xs-3">
                            <label for="exampleInputEmail1">IFSC Code<span style="color: red">*</span></label>
                            <asp:TextBox ID="txtifsc" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtIFSC" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    
                    
                    <div class="col-xs-3">
                            <label for="exampleInputEmail1">Address<span style="color: red">*</span> </label>
                            <asp:TextBox ID="txtaddress" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtaddress" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                        </div>
                        
                    <div class="form-group row">
                    <div class="col-xs-6">
                            <label for="exampleInputFile">Farmer Image</label>

                            <div class="form-group row">
                                <div class="col-xs-3">
                                    <asp:FileUpload ID="fpfarmer" runat="server" />
                                </div>
                                <div class="col-xs-3">
                                    <asp:Image ID="imgfarmer" Visible="false" Width="75px" Height="50px" runat="server" />
                                </div>
                                <div class="col-xs-3">
                                    <asp:Button ID="btnRemove" runat="server" Visible="false" CssClass="btn btn-danger" Text="X" CausesValidation="false" OnClick="btnRemove_Click" />
                                </div>
                                <div class="col-xs-3">
                                    <asp:Button ID="btnImageUpload" runat="server" CssClass="btn btn-info" Text="Upload" OnClick="btnImageUpload_Click" OnClientClick="return checkFileExtension()" />
                                </div>
                            </div>


                        </div>
                        </div>
                    </div>

                    <div class="form-group row">

                    <div class="col-xs-8">

                        <table class="table table-hover table-checkable order-column full-width" id="example4">
                            <thead>
                                <tr>

                                    <th class="center">ACTION </th>
                                    <%--<th class="center">SR NO </th>--%>
                                    <th class="center">Product</th>
                                    <th class="center">Rate</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">

                                            <td class="center">
                                                <asp:Button ID="Button2" class="form-control" CssClass="btn btn-info" runat="server" Text="REMOVE" OnClick="Remove_Product" CommandArgument='<%# Eval("id") %>' />
                                                <asp:Label ID="lblSrNo" Visible="false" runat="server" Text=' <%#Eval("id")%>'></asp:Label>
                                            </td>
                                            <%--<td class="center"><asp:Label ID="Label1" runat="server" Text=' <%#Eval("operation")%>'></asp:Label></td>--%>
                                            <td class="center">
                                                <asp:Label ID="lblproductid" runat="server" Visible="false" Text=' <%#Eval("productid")%>'></asp:Label>
                                                <%--<asp:Label ID="lblproductname" runat="server" Text=' <%#Eval("productname")%>'></asp:Label>
                                                    <asp:ListBox ID="lstproductrep" runat="server" class="form-control select2" OnSelectedIndexChanged="lstProductrep_SelectedIndexChanged"></asp:ListBox>
                                        <asp:HiddenField ID="hfproductidrep" runat="server" />
                                                    
                                                    --%>
                                                <asp:DropDownList ID="ddlOperationRep" Width="200" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlOperationRep_SelectedIndexChanged" AutoPostBack="true" />

                                            </td>
                                            <td class="center">
                                                <asp:TextBox ID="txtraterep" runat="server" class="form-control" Text=' <%#Eval("rate")%>' OnTextChanged="txtraterep_TextChanged"></asp:TextBox></td>
                                            <%--<asp:Label ID="lblrate" runat="server" Text=' <%#Eval("rate")%>'></asp:Label>--%>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>
                            <tfoot>
                                <tr class="odd gradeX">

                                    <th class="center">
                                        <asp:Button ID="btnAdd" runat="server" class="form-control" CssClass="btn bg-orange" CausesValidation="true" ValidationGroup="c1" Text="ADD" OnClick="btnAdd_Click" />
                                    </th>
                                    <th class="center">
                                        <%--<asp:ListBox ID="lstproduct" runat="server" class="form-control select2" OnSelectedIndexChanged="lstProduct_SelectedIndexChanged"></asp:ListBox>
                                        <asp:HiddenField ID="hfproductid" runat="server" />--%>
                                        <asp:DropDownList ID="ddlOperation" Width="200" runat="server" AutoPostBack="true" CssClass="form-control" />
                                        
                                    </th>

                                    <th class="center">
                                        <asp:TextBox ID="txtrate" class="form-control" runat="server" Text="0"></asp:TextBox>

                                    </th>


                                </tr>

                            </tfoot>
                        </table>
                    </div>

                        
                    </div>










                    <div class="form-group row">



                        <div class="col-md-12">
                            <div class="box-footer" style="text-align: center">

                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="c1" Text="SAVE" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn btn-default" OnClick="btnCancel_Click" Text="CANCEL" />
                            </div>
                        </div>
                    </div>





                </div>
                <%--</div>--%>


                <!-- /.box-body -->




                <!-- /.box -->

                <!-- Form Element sizes -->

                <!-- /.box -->


                <!-- /.box -->

                <!-- Input addon -->

                <!-- /.box -->

            </div>
            <!--/.col (left) -->
            <!-- right column -->

            <!--/.col (right) -->
        </div>
    </div>

    <%--        </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="btnImageUpload"/>
    </Triggers>
    </asp:UpdatePanel>--%>

    <!-- jQuery 3 -->
    <script src="Template/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="Template/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- DataTables -->
    <script src="Template/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="Template/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <!-- SlimScroll -->
    <script src="Template/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- FastClick -->
    <script src="Template/bower_components/fastclick/lib/fastclick.js"></script>
    <!-- AdminLTE App -->
    <script src="Template/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="Template/dist/js/demo.js"></script>


    <!-- Select2 -->
    <script src="Template/bower_components/select2/dist/js/select2.full.min.js"></script>

    <!-- page script -->


    <script type="text/javascript">
        function checkFileExtension() {
            var result = false;
            var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
            //var fileUpload = $("#ctl00_ContentPlaceHolder1_fpfarmer");

            if (($("#ctl00_ContentPlaceHolder1_fpfarmer").val() == "") || ($("#ctl00_ContentPlaceHolder1_fpfarmer").val() == null)) {
                //if ((document.getElementById("fpfarmer").val() == "") || (document.getElementById("fpfarmer").val() == null)) {

                if ((fileUpload.val() == "") || (fileUpload.val() == null)) {
                    alert("Please Upload Image.")
                    result = false;
                }
                else {
                    var allowedFiles = [".jpg", ".jpeg", ".bmp", ".gif", ".png", ".JPEG"];

                    var fileUpload = document.getElementById("ctl00_ContentPlaceHolder1_fpfarmer");
                    //var fileUpload = (document.getElementById("fpfarmer"));

                    var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");
                    if (!regex.test(fileUpload.value.toLowerCase())) {
                        alert("Please upload files having extensions:" + allowedFiles.join(', ') + " only.");
                        result = false;
                    }
                    else {
                        result = true;
                    }
                }

                return result;
            }
    </script>


    <script type="text/javascript">
            $(document).ready(function () {

                initDropDowns();

            });

            function pageLoad() {
                // JS to execute during full and partial postbacks
                initDropDowns();


            }
            function initDropDowns() {
                
<%--                $("#<%=lstproduct.ClientID%>").select2({

                    allowClear: true

                }).on('change.select2', function () {
                        $('[id*=hfproductid]').val($(this).val());
                    });


                var elemArray = document.getElementsByClassName('lstproductrep');
                for (var i = 0; i < elemArray.length; i++) {
                    var elem = elemArray[i].value;
                    elem.select2({

                    allowClear: true

                }).on('change.select2', function () {
                        $('[id*=hfproductidrep]').val($(this).val());
                    });
                }
                --%>


<%--                $("#<%=lstproductrep.ClientID%>").select2({

                    allowClear: true

                }).on('change.select2', function () {
         //alert("Selected value is: "+$("#<%=lstproductrep.ClientID%>").select2("val"));
                        $('[id*=hfproductid]').val($(this).val());
                    });--%>



            }



    </script>


    <script type="text/javascript">


</script>

</asp:Content>

