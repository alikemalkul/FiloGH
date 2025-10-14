window.__uiHelper = (function () {
    const api = {
        observeStarted: false,

        startObserving: function () {
            if (this.observeStarted) return;
            this.observeStarted = true;

            const mo = new MutationObserver(muts => {
                for (const m of muts) {
                    for (const n of m.addedNodes) {
                        if (n.nodeType !== 1) continue;
                        // yeni eklenen .mud-dialog-container var mı?
                        const container = (n.classList && n.classList.contains('mud-dialog-container')) ? n : (n.querySelector && n.querySelector('.mud-dialog-container'));
                        if (container) {
                            container.classList.add('dialog-animate');
                            container.classList.remove('dialog-closing');
                        }
                    }
                }
            });

            mo.observe(document.body, { childList: true, subtree: true });
            this._mo = mo;
        },

        // Açma animasyonunu hemen başlat (en üstteki dialog)
        dialogStartOpenAnimation: function () {
            const containers = document.querySelectorAll('.mud-dialog-container');
            if (!containers.length) return false;
            const container = containers[containers.length - 1];
            container.classList.add('dialog-animate');
            container.classList.remove('dialog-closing');
            return true;
        },

        // Kapatma animasyonu başlat
        dialogStartCloseAnimation: function () {
            const containers = document.querySelectorAll('.mud-dialog-container');
            if (!containers.length) return false;
            const container = containers[containers.length - 1];
            container.classList.remove('dialog-animate');
            container.classList.add('dialog-closing');
            return true;
        },

        // Eğer select popup'ı portal nedeniyle offscreen ise, bunu düzeltmek için
        fixMudSelectPopoverWhenOpen: function () {
            // MudBlazor popover'ı açıldıktan sonra .mud-popover.mud-popover-open olur
            const pop = document.querySelector('.mud-popover.mud-popover-open');
            if (!pop) return false;

            // Eğer zaten görünür ve pozisyonu sıfır / offscreen ise (örnek x < 1)
            const r = pop.getBoundingClientRect();
            if (r.width === 0 || r.height === 0 || r.left < 0 || r.top < 0) {
                // en son açılan dialog container'ını al
                const dialog = document.querySelector('.mud-dialog-container');
                if (!dialog) return false;
                // dialog içine taşı (gerekiyorsa) ve absolute konumlandır
                if (!dialog.contains(pop)) dialog.appendChild(pop);

                // referans input alanını bul (aynı dialog içindeki ilk mud-select)
                const ref = dialog.querySelector('.mud-select');
                if (!ref) return false;
                const refRect = ref.getBoundingClientRect();
                const dialogRect = dialog.getBoundingClientRect();

                pop.style.position = 'absolute';
                pop.style.left = `${Math.max(0, refRect.left - dialogRect.left)}px`;
                pop.style.top = `${Math.max(0, refRect.bottom - dialogRect.top + 6)}px`;
                pop.style.transform = 'none';
                pop.style.zIndex = 3000;
                return true;
            }
            return true; // zaten iyi
        }
    };

    // otomatik başlat
    window.addEventListener('DOMContentLoaded', () => api.startObserving());
    if (document.readyState === 'interactive' || document.readyState === 'complete') {
        api.startObserving();
    }

    return api;
})();
