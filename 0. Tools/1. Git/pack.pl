#! perl
use warnings;
use strict;

use App::cpm;
use PAR::Packer;
use Cwd;

my $filename = 'gitmqt.exe';
`cpm install -g`;
`pp -o $filename -B -M Test::More -M Git -M Cwd -M Test2::Event -M Test2::Event::Pass -M Test2::Event::Fail -M Test2::Event::V2 -M Test2/Formatter/TAP.pm -M Test2/Formatter.pm -M Error run.pl`;
print cwd, "/$filename\n";
