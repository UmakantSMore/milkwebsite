<%@ Page Title="" Language="C#" MasterPageFile="~/morya.master" AutoEventWireup="true" CodeFile="stockinward.aspx.cs" Inherits="stockinward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                            <h3><span style="color: red"></span></h3>
                            <h3 class="box-title" style="text-align: center"><b id="spnMessage" runat="server"></b></h3>
                            <%--<cc1:ToolkitScriptManager ID="toolScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <div class="box-body">

                            <%--<div class="form-group row">

                                <div class="col-xs-3">
                                    <label for="exampleInputEmail1">Farmer</label>
                                    <asp:ListBox ID="lstfarmer" runat="server" class="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="lstfarmer_SelectedIndexChanged"></asp:ListBox>
                                    <asp:HiddenField ID="hffarmerid" runat="server" />
                                </div>

                            </div>--%>

                            <div class="form-group row">
                                
                                <div class="col-xs-8" style="align-content:center">

                                    <table class="table table-hover table-checkable order-column full-width" id="example4">
                                        <thead>
                                            <tr >
                                                <th class="center">Product</th>
                                                <th class="center">Dispatched</th>
                                                <th class="center">Received</th>

                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr class="odd gradeX">

                                                        <td class="center">
                                                            <asp:Label ID="lblid" runat="server" Visible="false" Text=' <%#Eval("id")%>'></asp:Label>
                                                            <asp:Label ID="lblproductid" runat="server" Visible="false" Text=' <%#Eval("productid")%>'></asp:Label>
                                                            <asp:Label ID="lblproductname" runat="server" Text=' <%#Eval("productname")%>'></asp:Label>
                                                        </td>
                                                        <td class="center">
                                                            <asp:Label ID="txtreqqty" runat="server" Text=' <%#Eval("quantity")%>'></asp:Label>
                                                        </td>
                                                        <td class="center">
                                                            <asp:TextBox ID="txtqty" Width="120px" runat="server" class="form-control" Text="0"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtqty" ValidationGroup="gg" ValidationExpression="^\d+" ErrorMessage="*" Font-Bold="True" Font-Size="Large" />

                                                        </td>
                                                        <%--<asp:Label ID="lblrate" runat="server" Visible="false" Text=' <%#Eval("rate")%>'></asp:Label>--%>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                        <tfoot>
                                            <tr class="odd gradeX">

                                                <th class="center">Product</th>
                                                <th class="center">Dispatched</th>
                                                <th class="center">Received</th>



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

        </ContentTemplate>

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


    <!-- Select2 -->
    <script src="Template/bower_components/select2/dist/js/select2.full.min.js"></script>

    <!-- page script -->




<%--    <script type="text/javascript">
        $(document).ready(function () {

            initDropDowns();

        });

        function pageLoad() {
            // JS to execute during full and partial postbacks
            initDropDowns();


        }
        function initDropDowns() {

            $("#<%=lstfarmer.ClientID%>").select2({

                allowClear: true

            }).on('change.select2', function () {
                $('[id*=hffarmerid]').val($(this).val());
            });
            
        }



    </script>--%>



</asp:Content>


