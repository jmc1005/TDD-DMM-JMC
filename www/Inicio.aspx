<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="www.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/estilos.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <h3>
            <font face="Verdana">TDD-DMM-JMC</font>
        </h3>
        <table width="97%" align="center">
            <tr>
                <td style="width: 300px;">
                    <asp:Button Text="Validación" BorderStyle="None" ID="TabValidacion" CssClass="active" runat="server"
                        OnClick="TabValidacion_Click" />
                    <asp:Button Text="Estadística" BorderStyle="None" ID="TabEstadistica" CssClass="inactive" runat="server"
                        OnClick="TabEstadistica_Click" />

                </td>
            </tr>
        </table>
        <div width="97%" align="left" style="padding: 15px 15px 15px 15px; margin-top: 10px;">
            <asp:MultiView ID="MainView" runat="server">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 300px;">
                                <asp:TextBox ID="tbCodigoPostal" runat="server" CssClass="form-control" placeholder="Código postal"></asp:TextBox>
                            </td>
                            <td style="width: 300px; padding: 10px;">
                                <asp:Label ID="lbCodigoPostal" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px;">
                                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" placeholder="Correo electrónico"></asp:TextBox>
                            </td>
                            <td style="width: 300px; padding: 10px;">
                                <asp:Label ID="lbEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px;">
                                <asp:TextBox ID="tbNIF" runat="server" CssClass="form-control" placeholder="NIF"></asp:TextBox>
                            </td>
                            <td style="width: 300px; padding: 10px;">
                                <asp:Label ID="lbNIF" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px;">
                                <asp:TextBox ID="tbTarjetaCredito" runat="server" CssClass="form-control" placeholder="Tarjeta crédito"></asp:TextBox>
                            </td>
                            <td style="width: 300px; padding: 10px;">
                                <asp:Label ID="lbTarjetaCredito" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px;">
                                <asp:TextBox ID="tbCCC" runat="server" CssClass="form-control" placeholder="CCC bancario"></asp:TextBox>
                            </td>
                            <td style="width: 300px; padding: 10px;">
                                <asp:Label ID="lbCCC" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px;">
                                <asp:TextBox ID="tbIBAN" runat="server" CssClass="form-control" placeholder="IBAN Español"></asp:TextBox>
                            </td>
                            <td style="width: 300px; padding: 10px;">
                                <asp:Label ID="lbIBAN" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div style="margin-top: 20px; text-align: left;">
                        <asp:Button ID="btnValidar" runat="server" Text="Validar" OnClick="BtnValidar_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnLimpiarValidacion" runat="server" Text="Limpiar" OnClick="btnLimpiarValidacion_Click" CssClass="btn btn-secondary" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="form-group">
                        <asp:TextBox ID="tbListaValores" runat="server" CssClass="form-control" placeholder="Introduzca los valores separados por comas"></asp:TextBox>
                        <small id="listaValoresError" visible="false" runat="server" class="form-text text-danger">Por favor, introduzca los valores separados por comas</small>
                    </div>
                    <div style="padding: 15px 15px 15px 15px; margin-top: 5px;" class="form-check">
                        <asp:RadioButton ID="rbMediaAritmetica" Text="Media Aritmética" Checked="True" GroupName="EstadisticaGroup" runat="server" /><br />
                        <asp:RadioButton ID="rbMediaGeometrica" Text="Media Geométrica" GroupName="EstadisticaGroup" runat="server" /><br />
                        <asp:RadioButton ID="rbMediaArmonica" Text="Media Armónica" GroupName="EstadisticaGroup" runat="server" /><br />
                        <asp:RadioButton ID="rbMediana" Text="Mediana" GroupName="EstadisticaGroup" runat="server" /><br />
                        <asp:RadioButton ID="rbModa" Text="Moda" GroupName="EstadisticaGroup" runat="server" /><br />
                        <asp:RadioButton ID="rbDesviacionAbsoluta" Text="Desviación sin signo o absoluta" GroupName="EstadisticaGroup" runat="server" /><br />
                        <asp:RadioButton ID="rbDesviacionMediaConSigno" Text="Desviación media con signo" GroupName="EstadisticaGroup" runat="server" /><br />
                    </div>
                    <div id="divResult" class="alert alert-success" style="text-align:center" runat="server" visible="false">
                         <asp:Label ID="lbResult" runat="server" ></asp:Label>
                    </div>
                    <div style="margin-top: 20px; text-align: left;">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" CssClass="btn btn-primary" />
                         <asp:Button ID="btnLimpiarEstadistica" runat="server" Text="Limpiar" OnClick="btnLimpiarEstadistica_Click" CssClass="btn btn-secondary" />
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
