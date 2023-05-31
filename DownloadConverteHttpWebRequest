Imports System.Net.Http
Imports System.Threading.Tasks
Imports System.Web

Module Module1
    Sub Main()
        ' URL do arquivo .asp que contém a imagem
        Dim url As String = "https://solucoes.receita.fazenda.gov.br/servicos/cnpjreva/captcha/gerarCaptcha.asp"

        ' Criar uma instância de HttpClient
        Using httpClient As New HttpClient()
            ' Fazer a solicitação HTTP
            Dim responseTask As Task(Of HttpResponseMessage) = httpClient.GetAsync(url)

            ' Obter a resposta
            Dim response As HttpResponseMessage = responseTask.Result

            ' Verificar se a solicitação foi bem-sucedida
            If response.IsSuccessStatusCode Then
                ' Ler o conteúdo da resposta como um array de bytes
                Dim contentTask As Task(Of Byte()) = response.Content.ReadAsByteArrayAsync()
                Dim imageBytes As Byte() = contentTask.Result

                ' Criar um HttpResponse
                Dim httpResponse As HttpResponse = HttpContext.Current.Response

                ' Definir o código de status
                httpResponse.StatusCode = CType(response.StatusCode, Integer)

                ' Definir os cabeçalhos
                For Each header As KeyValuePair(Of String, IEnumerable(Of String)) In response.Headers
                    httpResponse.AppendHeader(header.Key, String.Join(",", header.Value))
                Next

                ' Definir o tipo de conteúdo
                httpResponse.ContentType = response.Content.Headers.ContentType.ToString()

                ' Escrever os bytes da imagem na resposta
                httpResponse.BinaryWrite(imageBytes)

                ' Finalizar a resposta
                httpResponse.End()
            Else
                ' Lidar com o erro da solicitação
                Console.WriteLine("Erro na solicitação: " & response.StatusCode)
            End If
        End Using
    End Sub
End Module
