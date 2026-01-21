#!/bin/bash

# Cores para o terminal
CYAN='\033[0;36m'
NC='\033[0m'

echo -e "${CYAN}Compilando a solução...${NC}"
dotnet build

echo -e "${CYAN}Iniciando API Application e abrindo Swagger...${NC}"
# Inicia a API e guarda o PID (ID do processo)
dotnet run --project ./Application --no-build & 

echo -e "${CYAN}Iniciando User Application e abrindo Swagger...${NC}"
dotnet run --project ./UserApplication --no-build &

# Pequena pausa para dar tempo das APIs subirem antes de abrir o navegador
sleep 2

# Abre o Swagger de cada uma no navegador padrão
# Ajuste as portas (5000, 5001, etc) conforme a sua configuração
xdg-open "http://localhost:5000/swagger"
xdg-open "http://localhost:6001/swagger"

echo -e "${CYAN}Tudo pronto! Pressione Ctrl+C para encerrar as APIs.${NC}"
wait
