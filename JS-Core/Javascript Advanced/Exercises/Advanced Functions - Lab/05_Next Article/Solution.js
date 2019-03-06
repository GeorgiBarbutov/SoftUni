function getArticleGenerator(articles) {
    return (() => {
        let counter = 0;
        let arr = articles;
        return () => {
            if(counter < arr.length){
                let div = document.getElementById("content");
                div.textContent += arr[counter];
                counter++;
            }
        }
    })();
}

let a = getArticleGenerator(["a", "b", "c"]);
a();
a();
a();
a();
a();