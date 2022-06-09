# screenshot_if_different_cs　これは何ですか？

定期的にスクリーンショットを取得します。

スクリーンショットの中で、保存する範囲を指定できます。

複数の監視領域を設けることができ、それぞれの監視領域で前回取得時と差があった場合、スクリーンショットのうち指定した領域を保存します。

PCの性能次第ですが、最速で0.1秒間隔で監視、保存できます。

保存形式は、PNG、JPG、BMPです。JPGが一番圧縮率が高いです。

監視領域は5つくらいまでは動作確認しました。

監視の設定では、まったく変化が無くても保存するようにできます。このとき、最速で0.1秒間隔で保存できます。

# 想定している用途（使うかどうかは・・）

朝から起動しておいて、一日のPC作業を振り返る紙芝居にする。

動画を観るのが面倒なので、大きく変化したところだけを紙芝居にする。

セミナーの録画を見返すのが面倒なので、資料が変化したところだけを紙芝居にする。

作ったソフトの使い方を紙芝居にする。

USBカメラをモニタして、変化があったとき保存する。

他、何らかのソフトの表示に変化があったとき保存する。

# 最新バイナリ

ScreenRecorderCs.zip

# 開発環境

windows pro 10 64bit ver 21H2 (OS build 19044,1706)

C# (Visual Studio 2019)

# 動作環境

windows pro 10 64bit ver 21H2 (OS build 19044,1706)

# 履歴

2020/6/9 保存範囲指定可能

2022/6/7 アップロード

2022/5/12 開始
