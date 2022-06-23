Public Class clsEnviarDatos_ION


    Public Sub enviar_SKU_ION(ByRef ds As DataSet)

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then

                For Each registro As DataRow In ds.Tables(0).Rows

                    Dim objDatos As New clsModelo_SKU
                    Dim strSKU As String = ""

                    Try

                        strSKU = Left(registro.Item("sku_referencia").ToString, 50)

                        objDatos.SKU = strSKU
                        objDatos.BUSR1 = Left(registro.Item("busr1_linprov").ToString, 30)
                        objDatos.BUSR2 = Left(registro.Item("busr2_grup").ToString, 30)
                        objDatos.BUSR3 = Left(registro.Item("busr3_cat").ToString, 30)
                        objDatos.BUSR4 = Left(registro.Item("busr4_tipo").ToString, 30)
                        objDatos.BUSR5 = Left(registro.Item("busr5_marca").ToString, 30)
                        objDatos.STORERKEY = Left(registro.Item("storerkey_cia").ToString, 15)
                        objDatos.DESCR = Left(registro.Item("descr_des").ToString, 60)
                        objDatos.PACKKEY = Left(registro.Item("packkey_pack").ToString, 50)
                        objDatos.STDCUBE = Left(registro.Item("stdcube_vol_individual").ToString, 15)
                        objDatos.STDGROSSWGT = Left(registro.Item("stdgrosswgt_peso_individual").ToString, 15)
                        objDatos.STDNETWGT = Left(registro.Item("stdnetwgt_peso_individual").ToString, 15)
                        objDatos.TARE = Left(registro.Item("tare_peso_tara").ToString, 15)
                        objDatos.SHELFLIFEINDICATOR = Left(registro.Item("shelflifeindicator_val_vidutil").ToString, 15)
                        objDatos.SHELFLIFEONRECEIVING = Left(registro.Item("shelflifeonreceiving_vutilent").ToString, 15)
                        objDatos.SHELFLIFE = Left(registro.Item("shelflife_vutilent").ToString, 15)
                        objDatos.SHELFLIFECODETYPE = Left(registro.Item("shelflifecodetype_valfechvence").ToString, 15)

                        ModuloSQL.sp_WMS_ION_Limpiar_SKU(strSKU)
                        ModuloSQL.sp_WMS_ION_DOWNLOAD_INT_SKU(objDatos)

                    Catch ex As Exception
                        ModuloSQL.sp_A_Registrar_Log_Download_SKU(True, strSKU, ds.GetXml(), "Se ha presentado una excepcion : " & ex.Message)
                    End Try

                Next

                'System.Threading.Thread.Sleep(10000)

            End If
        End If

    End Sub

End Class
