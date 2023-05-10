﻿var $applicationHelper = $applicationHelper || {};
$applicationHelper = function () {

    let paragraphDictionary = {
        1:  "<p><span class='fw-bold'>1</span> Gravida habitasse diam lacinia commodo himenaeos nisl. Faucibus lectus facilisis himenaeos. Mauris eget fermentum eleifend ipsum in. Tincidunt, aliquam dis congue? Nec nunc rutrum fringilla mus, pellentesque cubilia aenean primis. Sed congue neque accumsan eu pretium dui fringilla hac eleifend? Ad aliquam ultrices, pulvinar metus. Conubia etiam ullamcorper felis laoreet morbi dui. Laoreet aenean consectetur adipiscing magnis, mi morbi donec fames quisque rutrum. Orci per aenean dapibus nulla non taciti ut dictum inceptos nunc. Platea habitant montes dictum lorem ullamcorper netus inceptos vivamus adipiscing cubilia amet. Vitae a orci montes faucibus posuere! Tempor nascetur duis arcu tellus netus conubia at per sollicitudin nascetur libero. Dictumst dictum lobortis volutpat morbi maecenas lobortis, lorem natoque ut purus. Vitae proin ut lorem orci. Class ipsum odio eget porta cubilia ad commodo? A suscipit libero consequat phasellus suspendisse. Congue nam nostra maecenas. Duis conubia accumsan ac condimentum commodo aliquam donec potenti suscipit quis proin cum! Lectus fringilla sem etiam, ligula euismod feugiat. Ac aenean iaculis metus cursus placerat auctor rhoncus. Pulvinar feugiat, egestas.</p>",
        2:  "<p><span class='fw-bold'>2</span> Donec, pulvinar vitae eu. Aliquam placerat tincidunt hac magna neque sapien. Sagittis mollis hac ornare, pellentesque venenatis inceptos. Bibendum fusce consequat nam neque et class pulvinar interdum euismod netus. Sapien elit faucibus sed blandit elementum ultrices dui adipiscing est leo nascetur. Eleifend fringilla odio mollis nam imperdiet taciti fringilla felis euismod suspendisse tristique? Auctor cursus mollis nec non posuere. Purus imperdiet himenaeos massa rhoncus orci tellus, non adipiscing risus sapien. Curae; dolor sed tempus. Eleifend tincidunt donec fringilla et sollicitudin. Rutrum, placerat fringilla bibendum? Cum vitae pharetra consectetur. Montes natoque in lorem dolor morbi faucibus faucibus iaculis. Pulvinar conubia vehicula vitae curabitur habitant sollicitudin in mauris habitasse tincidunt nisi egestas. Convallis ridiculus.</p>",
        3:  "<p><span class='fw-bold'>3</span> Sapien sodales dui mattis montes iaculis aptent imperdiet. Leo aenean morbi dictumst cubilia massa neque sociis sed sociis morbi gravida. Venenatis curabitur vulputate, nec dignissim porttitor accumsan? Arcu praesent facilisi ridiculus elit iaculis potenti fringilla aliquet pharetra ultricies euismod! Facilisi luctus nam id ridiculus sagittis, tempus lobortis dictum scelerisque lacus diam! Diam mauris hendrerit sollicitudin, quis sapien venenatis massa parturient praesent. Nunc hac auctor nulla magna, scelerisque massa praesent arcu nullam vivamus euismod. Vel magna, vitae placerat! Consequat suscipit dictum eget duis pretium imperdiet cubilia senectus quis etiam magna maecenas? Sagittis pretium scelerisque arcu potenti varius dignissim venenatis volutpat euismod posuere nam netus. Torquent ante quam torquent eros congue sem porttitor faucibus ullamcorper cum conubia. Curae; nascetur.</p>",
        4:  "<p><span class='fw-bold'>4</span> Interdum adipiscing cursus ad, velit suspendisse potenti porta. Libero congue dictumst consequat hac quis aenean tempus. Dictumst nisl lectus varius habitasse nunc taciti quam duis? Inceptos et auctor posuere! Nulla taciti litora himenaeos netus in tincidunt convallis nec habitant inceptos! Suscipit eget arcu porta sociosqu neque facilisi volutpat lorem auctor fermentum duis. Litora maecenas erat sollicitudin; consequat cubilia pellentesque fusce id faucibus. Erat nostra risus turpis platea curae; tellus in adipiscing risus per! Mus dictumst consequat enim placerat!</p>",
        5:  "<p><span class='fw-bold'>5</span> Accumsan nascetur hendrerit torquent ac. Lorem ultrices ligula orci aliquam in fames, ante augue cursus! Aliquam dui odio vehicula sodales tempus neque egestas. Aliquam ligula pretium imperdiet auctor. Elit varius torquent pharetra arcu nostra nostra. Dictumst libero luctus praesent neque. Torquent morbi id at commodo ac, maecenas velit ornare torquent a suspendisse viverra. Pretium in placerat fusce ultrices cubilia lobortis neque. Habitasse senectus at purus pulvinar et rutrum ultricies. Non congue inceptos ultricies eleifend. A quis dui adipiscing, elementum orci. Consequat quis faucibus et facilisi adipiscing, magnis aliquet turpis diam taciti facilisi. Proin natoque hendrerit hendrerit nullam scelerisque lectus etiam nunc porttitor mi. Ac venenatis morbi proin ut risus in? Magna sociis magna aenean class tincidunt. Quisque aliquam vel habitant pretium fermentum enim morbi leo. Fames nisl purus dictumst netus class. Auctor, sed aenean mattis quisque. Tortor enim sapien congue ad suscipit. Penatibus ornare turpis netus per varius cras aenean volutpat praesent etiam aliquam. Suscipit aptent egestas montes at nibh augue cursus. Luctus risus pulvinar cursus posuere per?</p>",
        6:  "<p><span class='fw-bold'>6</span> Vitae non facilisi feugiat massa hendrerit nullam enim luctus eget dis vestibulum erat! Interdum montes lacinia mattis erat taciti ligula, libero penatibus semper dis sodales cubilia. Mollis dis, parturient cum amet. Elementum eu varius maecenas habitant? Accumsan fusce scelerisque ad phasellus quam. Aptent penatibus maecenas sodales nascetur auctor massa vel tempus, parturient aliquam? Lorem curae; sollicitudin mattis mattis; tellus sociis vehicula purus maecenas! Eget platea cursus tristique non lectus elementum nostra condimentum neque, rutrum himenaeos. Tempus lacinia ipsum fusce elementum. At, penatibus auctor condimentum. Nunc dictumst venenatis vestibulum lacus etiam nullam. Enim ac nostra; tempus dui eu libero est aenean massa conubia vulputate cubilia? Vel fusce molestie cursus velit. Porttitor sapien congue augue etiam lacinia curae; habitasse curabitur posuere faucibus elit fermentum. Blandit nisi varius curae; quis ac nascetur magnis elit taciti scelerisque justo. Lacus dapibus fames dignissim, morbi quam leo. Euismod amet vel faucibus, diam erat a pharetra netus erat. Rutrum nibh penatibus vehicula non platea amet? Cursus, lectus.</p>",
        7:  "<p><span class='fw-bold'>7</span> Non quisque gravida praesent platea dignissim iaculis at bibendum! Turpis class magna, urna ac eu habitasse eros vel diam bibendum dictumst. Dignissim ornare torquent tempus euismod. Fames varius varius lacinia nibh. Pulvinar porttitor mattis fusce orci tincidunt. Non dis per facilisi dictumst gravida. Cubilia semper nisl hac. Eleifend nisi phasellus pellentesque. Praesent parturient venenatis placerat interdum turpis suscipit pretium aliquet erat. Hendrerit quisque sem porta quisque porttitor lectus inceptos quisque. Lacus curabitur consectetur natoque habitant. Litora natoque platea sapien dui. Nostra praesent porta ullamcorper vel natoque. Et vel massa sem gravida? Felis velit in pharetra dapibus vestibulum duis erat lacinia rhoncus malesuada. Habitant et bibendum potenti euismod habitasse diam felis nulla tincidunt dictum. Inceptos convallis metus posuere eros urna pharetra! Vulputate litora suscipit lacinia et platea curabitur per proin mollis. Dui dui sed morbi dictumst! Ornare pharetra nisi aliquam praesent semper donec consectetur porta etiam lacus sed. Ipsum euismod inceptos fringilla molestie imperdiet non iaculis sodales vel. Inceptos eleifend faucibus class, ad leo.</p>",
        8:  "<p><span class='fw-bold'>8</span> Ac dui placerat netus. Sociis etiam sapien luctus mauris. Ullamcorper placerat mauris varius. Vehicula hac sodales dolor donec orci ultrices ornare, tortor in mus inceptos. Dapibus mattis donec, aliquet proin purus risus dictumst sapien conubia sagittis in? Odio feugiat dignissim tellus. Risus vel porttitor, tempor eros leo tortor pellentesque. Luctus hac quis senectus iaculis lobortis sodales consectetur. Natoque ad leo hac nunc orci tempor id nostra! Lacus et senectus eu, lectus torquent class. Lorem neque felis lacinia. Libero etiam ligula arcu bibendum vestibulum, sagittis amet arcu. Fermentum interdum ad sed amet class nam phasellus turpis curae; volutpat cras montes. Est nam aliquam eget iaculis dapibus orci iaculis faucibus tempus. Ultrices pellentesque dui dictum auctor, aenean dis nisl nunc. Nec aliquam nullam vel nisi tellus fames. Fringilla sem leo duis sem ultricies turpis ante lacinia mollis. Ornare magna class sodales posuere tempor blandit. Rutrum risus vitae purus bibendum sapien. In gravida aenean pharetra erat ridiculus iaculis phasellus nunc dolor ut. Sociosqu suscipit faucibus magna id justo!</p>",
        9:  "<p><span class='fw-bold'>9</span> Cum feugiat lacus consectetur purus, venenatis blandit lacus. Vel nisl, mi vehicula laoreet enim tempus hendrerit curae; elit. Rutrum hendrerit, feugiat magnis nam consectetur est eleifend ridiculus fames mollis vulputate hac. Ornare molestie aliquam lacinia per eget metus ridiculus sodales ad sollicitudin quam laoreet. Dictum rutrum erat facilisi vestibulum eget lectus sagittis sagittis rutrum urna tincidunt suscipit. In, ac luctus eleifend conubia porta blandit molestie. Sodales, sodales ac aliquet libero nulla fermentum amet. Netus a pretium conubia in ac a mollis elit. A blandit torquent nulla magna dictum potenti pharetra pharetra netus nostra lobortis. Netus luctus ullamcorper netus per commodo ridiculus imperdiet nibh adipiscing tempus porttitor? Phasellus sem fringilla fringilla vivamus tortor libero, facilisis elementum velit ligula penatibus. Facilisis, vel imperdiet lorem pharetra commodo felis porttitor litora nam himenaeos? Ultrices orci ultrices nulla tellus conubia imperdiet? Libero lacus vehicula varius purus netus massa eleifend aenean euismod vulputate. Pretium enim nulla sed cum integer posuere mi mi varius lectus.</p>",
        10: "<p><span class='fw-bold'>10</span> Sapien tellus donec scelerisque viverra commodo felis? Parturient aptent vitae accumsan malesuada. Orci feugiat blandit luctus ligula tortor mollis. Elementum est vel integer mi, varius ornare pretium habitant eros praesent commodo. Amet, dis mollis condimentum justo sollicitudin parturient ridiculus faucibus euismod ultrices dolor sociis. In molestie hac eros nisl fermentum netus maecenas eros himenaeos duis lectus vestibulum! Laoreet facilisi sem aliquet conubia, nullam class phasellus. Semper leo tincidunt ut. Interdum egestas, ullamcorper pulvinar. Maecenas sagittis mi neque sed pharetra amet erat himenaeos? Arcu et facilisis enim quis aenean cubilia imperdiet, accumsan morbi sem faucibus. Ad molestie suscipit magna proin. Nulla massa neque ut arcu mi viverra eget sodales mus sapien placerat augue! Sed ullamcorper ad tempor justo pretium vehicula. Montes vitae rutrum, etiam senectus varius! Eu.</p>	"
    };
    var getText = function (index) {
        console.log(typeof index);
        if (Object.keys(paragraphDictionary).includes(index.toString())) {
            return paragraphDictionary[index];
        } else {
            return "Not found";    
        }
    };


    return {
        getText: getText
    };
}();

