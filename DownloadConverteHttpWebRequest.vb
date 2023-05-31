Imports System.IO
Imports System.Net

Module Module1
    Sub Main()
        ' URL do arquivo .asp que contém a imagem
        Dim url As String = "https://solucoes.receita.fazenda.gov.br/servicos/cnpjreva/captcha/gerarCaptcha.asp"

        ' Criar uma instância de HttpWebRequest
        Dim request As HttpWebRequest = WebRequest.Create(url)
        request.Method = "GET"

        ' Fazer a solicitação HTTP e obter a resposta
        Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)

        ' Verificar se a solicitação foi bem-sucedida
        If response.StatusCode = HttpStatusCode.OK Then
            ' Ler o conteúdo da resposta como um array de bytes
            Dim stream As Stream = response.GetResponseStream()
            Dim memoryStream As New MemoryStream()
            stream.CopyTo(memoryStream)
            Dim imageBytes As Byte() = memoryStream.ToArray()

            ' Retornar o HttpWebResponse
            Console.WriteLine("Resposta HTTP obtida com sucesso.")

            ' Você pode usar o objeto 'response' conforme necessário
            ' Por exemplo, acessar os cabeçalhos da resposta:
            Console.WriteLine("Cabeçalhos da resposta:")
            For Each header As String In response.Headers.AllKeys
                Console.WriteLine(header & ": " & response.Headers(header))
            Next
        Else
            ' Lidar com o erro da solicitação
            Console.WriteLine("Erro na solicitação: " & response.StatusCode)
        End If
    End Sub
End Module
