Public Class clsEnviarDatos_ION

    Public Sub enviar_STORER_ION(ByRef ds As DataSet)

        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count > 0 Then

                For Each registro As DataRow In ds.Tables(0).Rows

                    Dim objDatos As New clsModelo_Storers
                    Dim strStorerKey As String = ""

                    Try

                        strStorerKey = Left(registro.Item("storerkey_key_client").ToString, 15)

                        objDatos.STORERKEY = strStorerKey
                        objDatos.TYPE = Left(registro.Item("type_tipo_client").ToString, 30)
                        objDatos.COMPANY = Left(registro.Item("company_des_client").ToString, 45)
                        objDatos.ADDRESS1 = Left(Replace(Replace(registro.Item("address1_dir1").ToString, Chr(10), ""), Chr(13), ""), 45)
                        objDatos.ADDRESS5 = Left(registro.Item("address5_nit").ToString, 45)
                        objDatos.ADDRESS6 = Left(registro.Item("address6_id_suc").ToString, 45)
                        objDatos.ADDRESS2 = Left(Replace(Replace(registro.Item("address2_barrio").ToString, Chr(10), ""), Chr(13), ""), 14)
                        objDatos.CITY = Left(registro.Item("city_ciudad").ToString, 45)
                        objDatos.STATE = Left(registro.Item("state_depto").ToString, 45)
                        objDatos.COUNTRY = Left(registro.Item("country_pais").ToString, 30)
                        objDatos.CONTACT1 = Left(Replace(Replace(registro.Item("contact1_contacto").ToString, Chr(10), ""), Chr(13), ""), 30)
                        objDatos.PHONE1 = Left(Replace(Replace(registro.Item("phone1_tel1").ToString, Chr(10), ""), Chr(13), ""), 18)
                        objDatos.PHONE2 = Left(Replace(Replace(registro.Item("phone2_cel1").ToString, Chr(10), ""), Chr(13), ""), 18)
                        objDatos.EMAIL1 = Left(Replace(Replace(registro.Item("email1_mail1").ToString, Chr(10), ""), Chr(13), ""), 50)
                        objDatos.SUSR1 = Left(registro.Item("susr1_canal").ToString, 30)
                        objDatos.SUSR2 = Left(registro.Item("susr2_zona_logist").ToString, 30)
                        objDatos.SUSR3 = Left(registro.Item("susr3_vend_act").ToString, 30)
                        objDatos.SUSR4 = Left(registro.Item("susr4_subcanal").ToString, 30)
                        objDatos.SUSR5 = Left(registro.Item("susr5_segmento").ToString, 30)
                        objDatos.SUSR6 = Left(registro.Item("susr6_subsegmento").ToString, 30)

                        ModuloSQL.sp_WMS_ION_Limpiar_STORERS(strStorerKey)
                        ModuloSQL.sp_WMS_ION_DOWNLOAD_INT_STORER(objDatos)

                    Catch ex As Exception
                        ModuloSQL.sp_A_Registrar_Log_Download_Receptores(True, strStorerKey, objDatos.ADDRESS5, ds.GetXml(), "Se ha presentado una excepcion " & ex.Message)
                    End Try

                Next

                'System.Threading.Thread.Sleep(10000)

            End If
        End If

    End Sub

End Class
