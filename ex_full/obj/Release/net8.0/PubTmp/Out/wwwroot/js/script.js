// wwwroot/js/script.js

// Funções para o modal de comentários
function abrirModalComentario() {
    document.getElementById('modalComentario').style.display = 'block';
    // Auto-focus no textarea
    setTimeout(() => {
        const textarea = document.querySelector('#modalComentario textarea');
        if (textarea) textarea.focus();
    }, 100);
}

function fecharModalComentario() {
    document.getElementById('modalComentario').style.display = 'none';
    // Limpar o textarea
    const textarea = document.querySelector('#modalComentario textarea');
    if (textarea) textarea.value = '';
}

// Funções para edição de comentários
function editarComentario(comentarioId) {
    document.getElementById('texto-' + comentarioId).style.display = 'none';
    document.getElementById('edicao-' + comentarioId).style.display = 'block';

    // Auto-focus no textarea de edição
    setTimeout(() => {
        const textarea = document.querySelector('#edicao-' + comentarioId + ' textarea');
        if (textarea) {
            textarea.focus();
            // Posicionar cursor no final
            textarea.setSelectionRange(textarea.value.length, textarea.value.length);
        }
    }, 100);
}

function cancelarEdicao(comentarioId) {
    document.getElementById('texto-' + comentarioId).style.display = 'block';
    document.getElementById('edicao-' + comentarioId).style.display = 'none';
}

// Variáveis para controle de exclusão
let comentarioParaExcluir = null;
let treinoParaRedirect = null;

function excluirComentario(comentarioId, treinoId) {
    comentarioParaExcluir = comentarioId;
    treinoParaRedirect = treinoId;
    document.getElementById('modalConfirmacao').style.display = 'block';
}

function fecharModalConfirmacao() {
    document.getElementById('modalConfirmacao').style.display = 'none';
    comentarioParaExcluir = null;
    treinoParaRedirect = null;
}

// Event listeners quando a página carrega
document.addEventListener('DOMContentLoaded', function () {
    // Configurar botão de confirmação de exclusão
    const btnConfirmar = document.getElementById('btnConfirmarExclusao');
    if (btnConfirmar) {
        btnConfirmar.onclick = function () {
            if (comentarioParaExcluir && treinoParaRedirect) {
                const form = document.createElement('form');
                form.method = 'POST';
                form.action = '/Treino/ExcluirComentario';

                const inputComentario = document.createElement('input');
                inputComentario.type = 'hidden';
                inputComentario.name = 'comentarioId';
                inputComentario.value = comentarioParaExcluir;

                const inputTreino = document.createElement('input');
                inputTreino.type = 'hidden';
                inputTreino.name = 'treinoId';
                inputTreino.value = treinoParaRedirect;

                form.appendChild(inputComentario);
                form.appendChild(inputTreino);
                document.body.appendChild(form);
                form.submit();
            }
        };
    }

    // Fechar modal com ESC
    document.addEventListener('keydown', function (event) {
        if (event.key === 'Escape') {
            fecharModalComentario();
            fecharModalConfirmacao();
        }
    });

    // Fechar modal clicando fora dele
    window.addEventListener('click', function (event) {
        const modalComentario = document.getElementById('modalComentario');
        const modalConfirmacao = document.getElementById('modalConfirmacao');

        if (event.target === modalComentario) {
            fecharModalComentario();
        }
        if (event.target === modalConfirmacao) {
            fecharModalConfirmacao();
        }
    });

    // Smooth scroll para comentários quando há muitos
    const comentariosContainer = document.querySelector('.gridcomentario');
    if (comentariosContainer) {
        comentariosContainer.style.scrollBehavior = 'smooth';
    }

    // Validação de formulários
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function (e) {
            const textarea = form.querySelector('textarea');
            if (textarea) {
                const texto = textarea.value.trim();

                if (texto.length < 5) {
                    alert('O comentário deve ter pelo menos 5 caracteres.');
                    e.preventDefault();
                    return false;
                }

                if (texto.length > 500) {
                    alert('O comentário não pode ter mais de 500 caracteres.');
                    e.preventDefault();
                    return false;
                }
            }
        });
    });
});

// Função para scroll suave até os comentários
function irParaComentarios() {
    const comentariosSection = document.querySelector('.gridcomentario');
    if (comentariosSection) {
        comentariosSection.scrollIntoView({ behavior: 'smooth' });
    }
}

// Função utilitária para mostrar notificações (opcional)
function mostrarNotificacao(mensagem, tipo = 'info') {
    // Implementação futura para notificações toast
    console.log(`${tipo.toUpperCase()}: ${mensagem}`);
}