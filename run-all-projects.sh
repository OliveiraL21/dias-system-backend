#!/bin/bash 

#Este comando interrompe o script se algum comando falhar
set -e

echo "Limpando e compilando os projetos..."
dotnet build

echo "Executando todos os projetos..."

# O '&' no final faz o comando rodar em background (segundo plano)
# Assim o script pode iniciar a próxima API sem esperar a primeira fechar
dotnet run --project ./Application --no-build &
dotnet run --project ./UserApplication --no-build &

# Mantém o script vivo para você ver os logs e conseguir parar tudo com Ctrl+C
wait
