using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yggdrasil.Enum
{
    public enum pLogin

    {
        SYS_HANDSHAKE_RES = -1,

        Begin = 3300,

        Request,
        Success,
        Failure,

        OnTheAnvil,     // preparando

        WaitTime,       // Latência de processamento de login

        FailureGSP,     // GSP: falha de autenticação
        RequestAeriaChannel,    // Canalização Aeria
        AccountBan,     //Enviar informações de banimento da conta
        Birthday,      //Enviar data de nascimento no Korea Shutdown System

        pSvr = 1700,

        ClusterList,
        SelectCluster,

        Change,                 //Alteração do servidor do jogo
        GoBackGate,            //do servidor do jogo para o servidor do portão
        GoBackAccount,         //portão -> servidor de conta

        AccessCode,            //AccessCode é gerado ao acessar a conta,

        //Autenticação do processo no servidor núcleo com o valor correspondente

        KillGate,
        KillSession,//UserIDX

        SelectPortal,//requisição e sucesso
        SelectPortalFailure,//falha

        LocalPortal,//sucesso do portal local

        TryLogin,//Se você já está logado e tente novamente, peça ao servidor núcleo para desconectar a pessoa que já está conectada

        ChannelInfo,//envia lista de canais e status do canal

        Pause,//pausa do servidor
        Resume,//reinicialização do servidor

        PrimiumStart,//informações do serviço de quarto do pc
        AlramExpire,//Notificação 5 minutos antes do término do serviço de sala de PC
        TimeExpire,//encerra o serviço de sala do pc
        PrimiumChange,//Altera o nível de serviço da sala do PC
        SelectCharacter,//inicia o jogo selecionando um personagem

        KoreaNumberCheck,

        SMS,

        MoveInstGame,

        TEST_GameServerLog,
        ChangeVersionCheck,
        PCBangServerDown,//Usado para excluir o efeito da sala de PC para todos os usuários quando o servidor de suporte da sala de PC acabar

        SkinUser,
        KillSession2,//TamerIDX

        EncryptionControl,

        TimeServerUserKick,//Sair de todos os usuários fechando o mapa cronometrado
        TimeMapClose,
        TimeMapOpen,

        ResourceHashReload,

        End
    };

    public enum Stagio

    {
        ErrID,
        ErrPass,

        Online,     // em uso
        Waiting,    // Autenticação em andamento
        Blocking,   // fora de uso

        ErrAge,     // menores de 12 anos

        NotOpen,    // O servidor ainda não foi aberto.
        Ban,        // acesso restrito

        HttpError,      // GSP: erro do servidor de autenticação
        AccoutDBError,  // GSP: erro de banco de dados do contrato de uso
        NotAgreement,   // GSP: Contrato de uso não
        IPBlock,            //GSP: Bloquear IP
        PlayTimeOut,
        PopErrMsg,  // Exibe a mensagem ERR

        SystemError,
        UNKNOWN_NICK,
        UNKNOWN_EMAIL,

        ErrLoginPass,   // Tipo de erro do servidor se ID/Senha estiver errado apenas na América do Norte
        EMPTY_TOKEN,
        UNKNOWN_TOKEN,
        UNKNOWN_TOKENTIME,
    };
}
