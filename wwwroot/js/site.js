// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const flagUrls = [
    { code: "ar", url: "https://flagpedia.net/data/flags/normal/ar.png", name:"Argentina" },
    { code: "au", url: "https://flagpedia.net/data/flags/normal/au.png", name: "World",  },
    { code: "br", url: "https://flagpedia.net/data/flags/normal/br.png", name: "Brazil", },
    { code: "ca", url: "https://flagpedia.net/data/flags/normal/ca.png", name: "Canada", },
    { code: "cn", url: "https://flagpedia.net/data/flags/normal/cn.png", name: "China", },
    { code: "fr", url: "https://flagpedia.net/data/flags/normal/fr.png", name: "France",  },
    { code: "de", url: "https://flagpedia.net/data/flags/normal/de.png", name: "Germany", },
    { code: "in", url: "https://flagpedia.net/data/flags/normal/in.png", name: "India",  },
    { code: "id", url: "https://flagpedia.net/data/flags/normal/id.png", name: "Indonesia", },
    { code: "it", url: "https://flagpedia.net/data/flags/normal/it.png", name: "Italy",  },
    { code: "jp", url: "https://flagpedia.net/data/flags/normal/jp.png", name: "Japan",  },
    { code: "kr", url: "https://flagpedia.net/data/flags/normal/kr.png", name: "Republic of Korea", },
    { code: "mx", url: "https://flagpedia.net/data/flags/normal/mx.png", name: "Maxico",  },
    { code: "ru", url: "https://flagpedia.net/data/flags/normal/ru.png", name: "Russia",  },
    { code: "sa", url: "https://flagpedia.net/data/flags/normal/sa.png", name: "Saudi Arabia",  },
    { code: "za", url: "https://flagpedia.net/data/flags/normal/za.png", name: "South Africa",  },
    { code: "tr", url: "https://flagpedia.net/data/flags/normal/tr.png", name: "Turkey",  },
    { code: "gb", url: "https://flagpedia.net/data/flags/normal/gb.png", name: "United Kingdom", },
    { code: "us", url: "https://flagpedia.net/data/flags/normal/us.png", name: "United State",},
];
let currentIndex = 0;

const displayFlags = () => {
    const flagContainer = document.getElementById("flagContainer");
    flagContainer.innerHTML = "";
    const headerContainer = document.getElementById("headerContainer");

    for (let i = currentIndex; i < currentIndex + 20; i++) {
        const flag = flagUrls[i % flagUrls.length];
        flagContainer.innerHTML += ` <button id="${flag.code}" class="flag-button flag-button-custom"><img src="${flag.url}" height="50" width="70" /></button>`;
    }
    const flagButtons = document.getElementsByClassName("flag-button-custom");
    for (let i = 0; i < flagButtons.length; i++) {
        flagButtons[i].addEventListener("click", function () {
            const flagData = flagUrls.find(flag => flag.code === this.id);
            const importData = flagData.importData;
            const exportData = flagData.exportData;
            const name = flagData.name;
            // Navigate to the trade page
            window.location.href = `/trade?name=${name}`
        });
    }
    currentIndex = (currentIndex + 1) % flagUrls.length;
};


displayFlags();
setInterval(displayFlags, 2000);


