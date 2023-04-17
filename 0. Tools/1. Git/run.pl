#! perl
use warnings;
use strict;
use Git;
use Cwd qw(cwd);
use feature qw(say signatures);
use Term::ExtendedColor qw(:all fg bg bold italic);
use File::Path qw(remove_tree);

my $lipsum_l =
    "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?";
my $lipsum_e =
    "But I must explain to you how all this mistaken idea of denouncing pleasure and praising pain was born and I will give you a complete account of the system, and expound the actual teachings of the great explorer of the truth, the master-builder of human happiness. No one rejects, dislikes, or avoids pleasure itself, because it is pleasure, but because those who do not know how to pursue pleasure rationally encounter consequences that are extremely painful. Nor again is there anyone who loves or pursues or desires to obtain pain of itself, because it is pain, but because occasionally circumstances occur in which toil and pain can procure him some great pleasure. To take a trivial example, which of us ever undertakes laborious physical exercise, except to obtain some advantage from it? But who has any right to find fault with a man who chooses to enjoy a pleasure that has no annoying consequences, or one who avoids a pain that produces no resultant pleasure?";
our $CWD      = cwd();
our $REPONAME = 'gitmqt';
my $git;

remove_tree $REPONAME, { verbose => 1, keep_root => 0 };

question(
    "Task 1: Clone the $REPONAME repository.\nHINT: repo url is https://github.com/fehho/scorpios-mqt",
    sub { 
        my $git_maybe;
        eval { $git_maybe = Git->repository( Directory => "$CWD/$REPONAME" ) };
        if( defined $git_maybe ){
            $git = $git_maybe;
            return $git_maybe;
        }
        return undef;
    },
    "Pass!",
    [
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

question(
    "Task 2: Check what branch you are on",
    sub ($response){
        return undef unless defined $response;
        return ( $response =~ /main/gi || undef );
    },
    "Pass!",
    [
        bold("NOTICE: You must use git through this console to complete this question.\n"),
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);


question(
     "Task 3: Change your current branch to dev",
     sub {
         return $git->command('show-branch') =~ /dev/gi || undef;
     },
    "Pass!",
    [
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

question(
    "Task 4: Create and select a branch named 'feature/feature-name'",
    sub {
        return $git->command('show-branch') =~ /feature\/feature-name/gi || undef;
    },
    "Pass!",
    [
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

question(
    "Task 5: Make some changes to the files inside $CWD/$REPONAME without tracking the changes, then press enter",
    sub {
        return $git->command('status') =~ /staged/gi || undef;
    },
    "Pass!",
    [
        "You can learn what a 'tracked change' is here https://git-scm.com/book/en/v2/Git-Basics-Recording-Changes-to-the-Repository (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

question(
    "Task 6: Make your changes tracked",
    sub {
        return $git->command('status') =~ /to be committed/gi || undef;
    },
    "Pass!",
    [
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

question(
    "Task 7: Commit your changes",
    sub {
        return $git->command('status') =~ /nothing to commit/gi || undef;
    },
    "Pass!",
    [
        "If you are using this terminal to input your answers, you will have to supply a one word message using the message flag.\n",
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

question(
    "Task 8: Merge the feature/feature-name branch into dev",
    sub {
        return $git->command( qw(branch --merged dev) ) =~ /feature\/feature-name/gi || undef;
    },
    "Pass!",
    [
        "",
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "l",
        " + bozo",
        " + ratio",
        " + skill issue",
        " + get on the phone",
        " + maidenless"
    ]
);

$git->command( qw(show HEAD) ) =~ /commit (\W*)/;
my $old_head = $1;

$git->command( qw(switch dev) );
open(my $fh_l, '+>>', "$REPONAME/README.md") or die $!;
say $fh_l $lipsum_l;
$git->command( qw(commit -am Latin) );
close $fh_l;
$git->command( qw(switch feature/feature-name) );
open(my $fh_e, '+>>', "$REPONAME/README.md") or die $!;
say $fh_e $lipsum_e;
$git->command( qw(commit -am English) );
close $fh_e;

question(
    "Task 8: You have been switched back to the feature-feature-name branch and must repeat the last task of merging dev and feature/feature-name, however this time you must help to fix a merge conflict in README.md",
    sub {
        $git->command( qw(show HEAD) ) =~ /commit (\W*)/;
        my $new_head = $1;
        my $head_changed = $old_head ne $new_head;
        my $is_merged    = $git->command( qw(branch --merged dev) ) =~ /feature\/feature-name/gi || undef;
        return ($is_merged) || undef;
    },
    "Pass!",
    [
        "",
        "",
        "",
        "",
        "Documentation can be found at https://git-scm.com/docs (CTRL+click to open)\n",
        "This will require editing README.md"
    ]
);

say fg('steelblue', bg('thistle3', 'Congratulations, you have passed!'));

sub question ($prompt_txt, $check, $success_msg, $failure_msg) {
    # store current repo state
    my $test_passed = undef;
    my $failure_count = 0;
    my $print_on_failure = '';
    until(defined $test_passed) {
        my ( $got_command, @got_args ) = split / /, Git::prompt($prompt_txt . bold("\n >>> git "));
        my $result;
        if( defined $got_command){
            if( defined $git ){
                use Try::Catch;
                try {
                    $result = $git->command($got_command, @got_args);
                } catch {
                    say $!;
                };
            } else {
                try {
                    $result = Git::command($got_command, @got_args);
                } catch {
                    say $!;
                };
            }
        }
        
        $test_passed = &$check($result) or undef;
        if (defined $test_passed) {
            say fg('steelblue', $success_msg);
        } else {
            if( ref $failure_msg ){
                $print_on_failure .= $failure_msg->@[$failure_count++] || '';
            } else {
                $print_on_failure = $failure_msg;
            }
            say fg('indianred', $print_on_failure);
        }
    }
    return $test_passed;
}