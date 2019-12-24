<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="addeditCustomerRegistration.aspx.cs" Inherits="addeditCustomerRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function dateselect(ev) {
            var calendarBehavior1 = $find("Calendar1");
            var d = calendarBehavior1._selectedDate;
            var now = new Date();
            calendarBehavior1.get_element().value = d.format("yyyy/MM/dd") + " " + now.format("HH:mm:ss")
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

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


                        <div class="box-body">


                            <div class="form-group row">

                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Name<span style="color: red">*</span> </label>
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtName" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">E-mail<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox></td>
                       
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                </div>
                            </div>


                            <div class="form-group row">
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Phone No<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtPhoneno" CssClass="form-control" runat="server"></asp:TextBox></td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtPhoneno" CssClass="error" ErrorMessage="Required Field" ValidationGroup="c1"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Password  <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtpassword" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtpassword" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Address  <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtAddress1" CssClass="form-control" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtAddress1" ValidationGroup="gg" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-xs-6">
                                    <table class="table table-user-information">
                                        <tbody>
                                            <tr>
                                                <td style="width: 100px; font-weight: bold">Image</td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="fpCategory" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:Image ID="imgCategory" Visible="false" Width="75px" Height="50px" runat="server" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRemove" runat="server" Visible="false" CssClass="btn btn-danger" Text="X" CausesValidation="false" OnClick="btnRemove_Click" />
                                                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnImageUpload" runat="server" CssClass="btn btn-info" Text="UPLOAD" OnClick="btnImageUpload_Click" OnClientClick="return checkFileExtension()" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;<%-- <asp:RequiredFieldValidator ID="RFVfpCategory" runat="server" Display="Dynamic" ControlToValidate="fpCategory" CssClass="error" ErrorMessage="This is required field" ValidationGroup="c1"></asp:RequiredFieldValidator>--%></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Anniversary Date   <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtAnnivarsaryDate" runat="server" class="form-control" autocomplete="off"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Anniversary Date" ControlToValidate="txtAnnivarsaryDate" ValidationGroup="gg" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="imgPopup" runat="server" TargetControlID="txtAnnivarsaryDate" Format="yyyy/MM/dd"></cc1:CalendarExtender>
                                </div>
                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Birth Date   <span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtBirthdate" runat="server" class="form-control" autocomplete="off"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Birth Date" ControlToValidate="txtBirthdate" ValidationGroup="gg" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtBirthdate" Format="yyyy/MM/dd"></cc1:CalendarExtender>
                                </div>
                            </div>


                            <div class="form-group row">

                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Business<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtBusiness" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>

                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Job</label>
                                    <asp:TextBox ID="txtJob" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>


                            </div>
                            <div class="form-group row">

                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Reference<span style="color: red">*</span></label>
                                    <asp:TextBox ID="txtReference" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>

                                <div class="col-xs-6">
                                    <label for="exampleInputEmail1">Days</label>
                                    <br />

                                    <asp:RadioButton ID="rdoDays_daily" runat="server" Text="Daily" GroupName="a" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdoDays_alternetdays" runat="server" Text="Alternet Days" GroupName="a" />
                                </div>


                            </div>
                            <div class="form-group row">

                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Days Shift<span style="color: red">*</span></label>
                                    <br />

                                    <asp:RadioButton ID="rdoShift_morning" runat="server" Text="Morning" GroupName="b" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdoShift_evening" runat="server" Text="Evening" GroupName="b" />

                                </div>

                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Days Time</label>
                                    <br />

                                    <asp:RadioButton ID="rdoDayTime_6To8" runat="server" Text="6am To 8 am" GroupName="c" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdoDayTime_after8" runat="server" Text="After 8am" GroupName="c" />

                                </div>



                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Door Step Delivery<span style="color: red">*</span></label>
                                    <br />

                                    <asp:RadioButton ID="rdodoorstepDelivery_doorbell" runat="server" Text="Doorbell" GroupName="d" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdodoorstepDelivery_withoutDoorbell" runat="server" Text="Without Doorbell" GroupName="d" />

                                </div>



                            </div>
                            <div class="form-group row">

                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Select Product<span style="color: red">*</span></label>
                                    <br />
                                    <asp:DropDownList ID="ddlProduct" CssClass="form-control" runat="server"></asp:DropDownList>


                                </div>

                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Quantity</label>
                                    <br />
                                    <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>

                                </div>



                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1"><span style="color: red">*</span></label>
                                    <br />
                                    <asp:Button ID="btnAddProduct" runat="server" CssClass="btn btn-primary" ValidationGroup="c2" Text="Add" OnClick="btnAddProduct_Click" />&nbsp;&nbsp;
                                   
                                </div>



                            </div>
                            <div class="form-group row">
                                <table id="example1" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>

                                            <th style="text-align: center">Sr</th>
                                            <th style="text-align: center">Product Name</th>
                                            <th style="text-align: center">Quantity</th>
                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </thead>


                                    <tbody>
                                        <asp:Repeater ID="repProduct" runat="server" >
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="text-align: center">
                                                          <asp:Label ID="txtsr" runat="server" Text='<%# Eval("sr") %>'></asp:Label>
                                                        </td>
                                                  
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblProductId" runat="server" Visible="false" Text='<%# Eval("fk_productId") %>'></asp:Label>
                                                         <asp:Label ID="lblProductName" runat="server"  Text='<%# Eval("productName") %>'></asp:Label>
                                                       
                                                    </td>

                                                     <td style="text-align: center">
                                                        <asp:TextBox ID="lblQty" runat="server" OnTextChanged="lblQty_TextChanged"  Text='<%# Eval("qty") %>'></asp:TextBox>
                                                       
                                                    </td>
                                                    <td style="text-align: center">
                                                        <%--<asp:HyperLink ID="hlEdit" runat="server" Style="text-decoration: underline" class="btn btn-success" Text="Edit"></asp:HyperLink>&nbsp;--%>
                                           <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" class="btn btn-danger" OnClientClick="return confirm('Do you want to delete this Product?');" OnClick="lnkDelete_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                    <tfoot>
                                        <tr>

                                            <th style="text-align: center">Image</th>

                                            <th style="text-align: center">Action</th>
                                        </tr>
                                    </tfoot>
                                </table>

                            </div>
                            <br />

                            <%--<div class="form-group row">

                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Select Product<span style="color: red">*</span></label>
                                    <asp:DropDownList ID="ddlProduct" Class="form-control" runat="server"></asp:DropDownList>

                                </div>

                                <div class="col-xs-3">

                                    <label for="exampleInputEmail1">Quantity </label>
                                    <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_price" ValidationGroup="productAdd" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>


                                </div>
                                 <div class="col-xs-3">
                                      <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="productAdd" Text="Add" OnClick="btnAdd_Click" />
                                     </div> 

                            </div>--%>

                            <div class="col-md-12">
                                <div class="box-footer" style="text-align: center">

                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" CausesValidation="true" ValidationGroup="c1" Text="SAVE" OnClick="btnSave_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn btn-default" OnClick="btnCancel_Click" Text="CANCEL" />
                                </div>
                            </div>





                            </>
                 <%--</div>--%>
                   
                </>
                <!-- /.box-body -->



                            </>
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
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnImageUpload" />
        </Triggers>

    </asp:UpdatePanel>

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
    <!-- page script -->
    <script type="text/javascript">
        function checkFileExtension() {
            var result = false;
            var _validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png"];
            //if (($("#ctl00_ContentPlaceHolder1_fpCategory").val() == "") || ($("#ctl00_ContentPlaceHolder1_fpCategory").val() == null)) {
            if ((document.getElementById("fpCategory").val() == "") || (document.getElementById("fpCategory").val() == null)) {
                alert("Please Upload Image.")
                result = false;
            }
            else {
                var allowedFiles = [".jpg", ".jpeg", ".bmp", ".gif", ".png", ".JPEG"];
                //var fileUpload = document.getElementById("ctl00_ContentPlaceHolder1_fpCategory");
                var fileUpload = document.getElementById("fpCategory");
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
</asp:Content>
